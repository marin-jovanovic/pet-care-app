# pet-care-app

app is tested for ubuntu 20.04
if used on Windows script
        
    /runners/aes_gcm.sh 

needs to be rewritten as batch file and file path location needs to be redefined in 
    
    /src_node/db_manager/crypto_manager.js


#install

    $chmod +x /runners/aes_gcm.sh

    $pip install -r requirements.txt

    $npm i

generate sql scripts for node

    setup script you want to generate in function main
    
    $python3 /src_py/sql_converter/main.py 

fill database using node
    
    $nodemon /src_node/db_manager/seed.js

    $nodemon /src_node/db_manager/crypto_seed.js


#run
        to do
