// require('child_process').execSync(
//     'pwd',
//     {stdio: 'inherit'}
// );

const child_process = require('child_process');
var path = require('path');
const { json } = require('stream/consumers');


async function encrypt_data(password, content) {


    password = {"master_password":password}

    let encrypt_script = path.resolve(__dirname, "..", "..", "src_py", "encrypt.sh")

    // chmod +x on this script
    let p = child_process.execSync(
        encrypt_script + ' -e \''+JSON.stringify(password)+ '\' "' + content + '"'
    ); 

    let returned_data = p.toString()

    as_j = await JSON.parse(returned_data)

    return as_j

}

async function decrypt_data(password, content) {
    password = {"master_password":password}
    
    let encrypt_script = path.resolve(__dirname, "..", "..", "src_py", "encrypt.sh")

    // chmod +x on this script
    let p = child_process.execSync(
        encrypt_script + ' -d \''+JSON.stringify(password)+ '\' \'' + JSON.stringify(content) + '\''
    );

    let returned_data = p.toString()

    as_j = await JSON.parse(returned_data)

    return as_j
}

(async () => {

    let mp ="vD15<>$%dmqw"
    let msg = "helloworld"
    console.log(msg) 

    let encrypter = await encrypt_data(mp, msg)
    console.log(encrypter)

    // let nonce = encrypter["nonce"]
    // let ciphertext = encrypter["ciphertext"]
    // let tag = encrypter["tag"]
    // let salt = encrypter["salt"]

    // console.log(nonce, ciphertext, tag, salt)

    // let encrypter = {
    //     nonce: 'Sis0fxWtIeSZGBA7j1amCA==',
    //     ciphertext: 'GAl1goQTJj8qJQ==',
    //     tag: 'H9t2BG+Vy4fiv6H8eydRqA==',
    //     salt: 'WeLhZ/fv89XPl1en9FeCjw=='
    // }
    
    // t = JSON.stringify(encrypter)

    // console.log(t)

    let decrypter = await decrypt_data(mp, encrypter)
    console.log(decrypter)

    // console.log("start")
    
    // console.log(process.argv0)


    // console.log("--")

    // console.log(process.argv)

    // let filename = process.argv[1]

    // let t = path.basename(path.dirname(filename))

    // f = '{"nonce": "3KiW4/XsoTeJbNhXl9SXsg==", "ciphertext": "eNQIbpJXO3ip+9OV9SwmnJmMrCbV6axxG5aczi1Tk5QDQGw=", "tag": "F6yPUepuOlH7A8veWDrcOA==", "salt": "Q6um26tOiTK9qgscimEE1Q=="}'

    // a = await JSON.parse(f)

    // console.log(a)

    // console.log(p.toString())

    // let f = child_process.execSync('pwd');


    // console.log(f.toString())

})();
