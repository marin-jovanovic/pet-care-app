require('dotenv').config();
const {Pool} = require('pg');
const crypto_manager = require('./crypto_manager');
const crypto = require("crypto");

const pool = new Pool({
    user: process.env.DB_USER,
    host: process.env.DB_HOST,
    database: process.env.DB_DATABASE,
    password: process.env.DB_PASSWORD,
    port: Number(process.env.DB_PORT),
});

function get_pool() {
    return pool
}

async function query(text, params) {
    const start = Date.now();
    return pool.query(text, params)
        .then(res => {
            const duration = Date.now() - start;
            console.log('executed query', {text, params, duration, rows: res.rows});
            return res;
        });

}

async function crypto_query_wrapper(statement, params, info_table) {
//     query = await db_index.crypto_query_wrapper(
//     'INSERT INTO recive (userName, idmessages) VALUES ( $2, $3);', 
//     ['PeroPeric', 0],
//     "recive"
// )

    // var digest = 'sha256';
    // var digestLen = 32;

    // function X963KDF(sharedSecret, sharedInfo, keySize){
    //     var maxCount = Math.ceil(keySize/digestLen);
    //     var result = Buffer.allocUnsafe(0);
    //     for (var count = 1; count < maxCount + 1; count++){
    //         var counter = Buffer.allocUnsafe(4);
    //         counter.writeUInt32BE(count, 0);
    //         var current = Buffer.concat([sharedSecret, counter, sharedInfo]);
    //         var hash = crypto.createHash(digest).update(current).digest();
    //         result = Buffer.concat([result, hash]);
    //     }
        
    //     return result.slice(0, keySize);
    // }

    // var sharedSecret = Buffer.from('2lvSJsBO2keUHRfvPG6C1RMUmGpuDbdgNrZ9YD7RYnvAcfgq/fjeYr1p0hWABeif', 'base64')
    // var sharedInfo = Buffer.from('04389128d9cf88f51be686a56b7d6792609a5cc0748b25b2dd0f77a7a7cdeef3f111049494556c227909ccf041aa65b5154218d4a040dc141bdd6dd0bf86a467c91b96a6e6beea44fc42733ca6d139914136fc69bd53871e03b6a9a7661c08c74a', 'hex');

    // var keyiv = X963KDF(sharedSecret, sharedInfo, 48);
    // var key = keyiv.slice(0,32).toString('base64');
    // var iv = keyiv.slice(32, 48).toString('base64');
    // console.log("Key: ", key); // Key:  mAzkYatDlz4SzrCyM23NhgL/+mE3eGgfUz9h1CFPhZM=
    // console.log("IV: ", iv); // IV:  rV3qrszd0PMPgeRhNnlOYA==



    // console.log(statement)
    // console.log(params)
    // console.log(info_table)
// "timestamp", in msg

    to_enc = {
        "person": ["email", "password", "mobileNumber"],
        "appuser": ["oib", "birthday", "gender", "name", "surname"],
        "messages": ["body"],
        "card": ["cardNumber", "validUntil", "CVV", "address", "cardType"],
        // "recive": ["username"]
    }

    username = info_table["__username"]
    table = info_table["__table"]
    session_password = info_table["__key"] 
    

    q = await query("select nonce, tag, salt from person natural join cipher where username = $1", [username])    

    q = q.rows[0]

    if (q === undefined) {
 
        console.log("undefined cipher object")
 
        new_cip = {
            nonce: {}, 
            salt: {},
            tag: {},
        }


    } else {
        new_cip = {
            nonce: JSON.parse(q["nonce"]), 
            salt: JSON.parse(q["salt"]), 
            tag: JSON.parse(q["tag"])
        }
    
    }

    // console.log("q rows")
    // console.log(q.rows[0])

    // q = await query("update cipher set nonce = $1, tag = $2, salt = $3 from person where person.idciper = cipher.idciper and username = $4", [{"a": "d"}, {"b": "c"}, {"c": "f"},username])    

    // return

    // // query = await query("select * from person join cipher on person.idcipher = cipher.idciper", [])    


    // // console.log(query.rows)

    // const keySize = 16; // for AES-128
    // const salt = crypto.randomBytes(16);
    // let key = crypto.pbkdf2Sync('password', salt, 10000, keySize, 'sha256');

    // key = key.toString()

    // console.log("key---------------------------------------")
    // console.log(key)

    // session_password =key

    cripted_params = []


    is_sth_to_be_cripted = false

    for (let i = 0; i < params.length; i++) {

        p = params[i]

        if (to_enc[table] !== undefined && to_enc[table].includes(p[0])) {

            console.log("kriptiraj", p)

            function hasWhiteSpace(s) {
                return /\s/g.test(s);
            }

            result = p[1]
            while (hasWhiteSpace(result)) {
                result = result.replace(" ", "_")
            }

            mp = session_password
            // let msg = "helloworld"
            msg = String(result)
            // console.log(msg) 

            let encrypter = await crypto_manager.encrypt_data(mp, msg)
            console.log(encrypter)

            new_cip["nonce"][p[0]] = encrypter.nonce
            new_cip["salt"][p[0]] = encrypter.salt
            new_cip["tag"][p[0]] = encrypter.tag

            c_val = encrypter.ciphertext
            cripted_params.push(c_val)
            // let decrypter = await decrypt_data(mp, encrypter)
            // console.log(decrypter)

            is_sth_to_be_cripted = true

        } else {
            cripted_params.push(p[1])
        }

    } 

    console.log("cripted params", cripted_params)
    console.log("new cip obj", new_cip)


    console.log(statement)

    await query(statement, cripted_params)    

    if (is_sth_to_be_cripted) {

        await query(

            "update cipher set nonce = $1, tag = $2, salt = $3 from person where person.idciper = cipher.idciper and username = $4", 
            [
                new_cip["nonce"], 
                new_cip["salt"], 
                new_cip["tag"], 
                username]
        )    
    
    }


    // console.log(statement)
    // console.log(params)
    // console.log(info_table)



}



module.exports = {
    get_pool, 
    query,
    crypto_query_wrapper,

    // query: (text, params) => {
    //     const start = Date.now();
    //     return pool.query(text, params)
    //         .then(res => {
    //             const duration = Date.now() - start;
    //             console.log('executed query', {text, params, duration, rows: res.rows});
    //             return res;
    //         });
    // },
    // po
}