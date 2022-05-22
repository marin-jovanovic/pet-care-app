import argparse
import json
import textwrap
from base64 import b64encode, b64decode

from Crypto.Cipher import AES
from Crypto.Protocol.KDF import scrypt
from Crypto.Random import get_random_bytes


def get_key(key: str, salt=None) -> (str, str):
    """
    generates key using key derivation function {scrypt}

    :param key: str; master key
    :param salt: str; salt if known
    :return: key and salt
    """

    if salt is None:
        salt = get_random_bytes(16)

    key = scrypt(key, salt, 16, N=2 ** 20, r=8, p=1)

    return key, salt


def is_password_strong(password: str) -> bool:
    """
    checks if {password} is strong enough

    :return: is_password_strong_enough: bool
    """

    flag = True

    if len(password) < 8:
        print("len of pass not enough")
        flag = False

    test_list = ["?", "!", "%", "&", "@"]
    if not any(item in list(password) for item in test_list):
        print("not one special char from ", test_list)
        flag = False

    return flag


def get_decrypted(params, json_input):
    """
    attempts to decrypt ciphertext using provided plaintext, key, tag, salt and
    nonce

    checks integrity

    salt is used for key derivation

    returns plaintext and {True}: bool if provided key is correct
    returns {""}: str and {False}: bool if provided key is false

    :param params: all data for decrypt process
    :param json_input: ciphertext which is to be decrypted
    :return: ("plaintext": json, "is_decrypted_successfully": bool)
    """

    if "master_password" not in params:
        return "master pass not params"

    master_password = params["master_password"]
    b64 = json_input

    json_k = ['nonce', 'ciphertext', 'tag', "salt"]
    jv = {k: b64decode(b64[k]) for k in json_k}

    key, _ = get_key(master_password, jv["salt"])

    cipher = AES.new(key, AES.MODE_GCM, nonce=jv['nonce'])

    try:
        plaintext = cipher.decrypt_and_verify(jv['ciphertext'], jv['tag'])
        t = plaintext.decode("utf-8")

        return json.dumps({"plaintext": t, "is_decrypted_successfully": True})

    except ValueError as e:

        if len(e.args) > 0 and e.args[0] == 'MAC check failed':

            json_k = ['is_decrypted_successfully']
            json_v = [b64encode(x).decode('utf-8') for x in
                      ("False",)]
            result = json.dumps(dict(zip(json_k, json_v)))
            return result

        else:
            raise e


def get_encrypted(params, plaintext):
    """
    encrypts based on GCM cipher and ensures integrity
    transforms {plaintext}: str to {ciphertext}: str

    assumption that @params["master_password"] is entered twice
      and that user it matches (first and second entry)

    :param pt: plaintext which is transformed to ciphertext
    :param master_pass: key
    :return: json(nonce, ciphertext, tag, salt)
    """

    if "master_password" not in params:
        return "master pass not params"

    master_password = params["master_password"]

    if not is_password_strong(master_password):
        return "master_password not strong"

    key, salt = get_key(master_password)

    data = plaintext.encode("ascii")

    cipher = AES.new(key, AES.MODE_GCM)
    ciphertext, tag = cipher.encrypt_and_digest(data)
    json_k = ['nonce', 'ciphertext', 'tag', "salt"]
    json_v = [b64encode(x).decode('utf-8') for x in
              (cipher.nonce, ciphertext, tag, salt)]
    result = json.dumps(dict(zip(json_k, json_v)))

    return result


def main():
    parser = argparse.ArgumentParser(
        description="encrypt and decrypt data using AES GCM",
        epilog=textwrap.dedent("""
            encrypt flag
            -e or --encrypt
            
            decrypt flag
            -d or --decrypt
            
        """),
        formatter_class=argparse.RawDescriptionHelpFormatter,
        fromfile_prefix_chars='@'
    )

    parser.add_argument('--encrypt', '-e', default=False,
                        help='encrypt flag', action='store_true')

    parser.add_argument('--decrypt', '-d', default=False,
                        help='decrypt flag', action="store_true")

    parser.add_argument('--secret', '-s', default=None,help='secret configuration, minimal: {"master_password": str}', type=json.loads)

    parser.add_argument('--plaintext', '-p', default=None, help='plaintext',
                        type=str)

    parser.add_argument('--ciphertext', '-c', default=None, help='ciphertext, minimal {"nonce": str, "ciphertext": str, "tag": str, "salt": str}',type=json.loads)

    args = parser.parse_args()

    if not args.encrypt and not args.decrypt:
        parser.print_help()
        raise ValueError("must select mode")

    if not args.secret:
        parser.print_help()
        raise ValueError("must provide secret configuration")

    if not args.secret["master_password"]:
        parser.print_help()
        raise ValueError("must provide minimal configuration (master_password)")

    if args.encrypt:

        if not args.plaintext:
            raise ValueError("must provide plaintext")

        ret = get_encrypted(
            args.secret,
            args.plaintext
        )

        print(ret)

    elif args.decrypt:

        if not args.ciphertext:
            raise ValueError("must provide ciphertext")

        ret = get_decrypted(
            args.secret,
            args.ciphertext
        )

        print(ret)


if __name__ == '__main__':
    main()
