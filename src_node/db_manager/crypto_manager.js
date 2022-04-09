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

    let decrypter = await decrypt_data(mp, encrypter)
    console.log(decrypter)

})();
