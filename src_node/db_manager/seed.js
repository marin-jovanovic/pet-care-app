const db_index = require('./db_executor');
const seed_create = require('./seed_create');
const seed_insert = require('./seed_insert');

(async () => {
    let query;

    console.log("start")

    query = await db_index.query(seed_create.create_table_location, [])
    query = await db_index.query(seed_create.create_table_session, [])
    query = await db_index.query(seed_create.create_table_period, [])
    query = await db_index.query(seed_create.create_table_pettype, [])
    query = await db_index.query(seed_create.create_table_breed, [])
    query = await db_index.query(seed_create.create_table_cipher, [])
    query = await db_index.query(seed_create.create_table_person, [])
    query = await db_index.query(seed_create.create_table_admin, [])
    query = await db_index.query(seed_create.create_table_appuser, [])
    query = await db_index.query(seed_create.create_table_descriptable, [])
    query = await db_index.query(seed_create.create_table_review, [])
    query = await db_index.query(seed_create.create_table_adlisting, [])
    query = await db_index.query(seed_create.create_table_pet, [])
    query = await db_index.query(seed_create.create_table_messages, [])
    query = await db_index.query(seed_create.create_table_card, [])
    query = await db_index.query(seed_create.create_table_give, [])
    query = await db_index.query(seed_create.create_table_contains, [])
    query = await db_index.query(seed_create.create_table_report, [])
    query = await db_index.query(seed_create.create_table_recive, [])
    
    // query = await db_index.query(seed_insert.insert_into_location, [])
    // query = await db_index.query(seed_insert.insert_into_session, [])
    // query = await db_index.query(seed_insert.insert_into_period, [])
    // query = await db_index.query(seed_insert.insert_into_pettype, [])
    // query = await db_index.query(seed_insert.insert_into_breed, [])
    // query = await db_index.query(seed_insert.insert_into_cipher, [])
    // query = await db_index.query(seed_insert.insert_into_person, [])
    // query = await db_index.query(seed_insert.insert_into_public_admin, [])
    // query = await db_index.query(seed_insert.insert_into_appuser, [])
    // query = await db_index.query(seed_insert.insert_into_descriptable, [])
    // query = await db_index.query(seed_insert.insert_into_review, [])
    // query = await db_index.query(seed_insert.insert_into_adlisting, [])
    // query = await db_index.query(seed_insert.insert_into_pet, [])
    // query = await db_index.query(seed_insert.insert_into_messages, [])
    // query = await db_index.query(seed_insert.insert_into_card, [])
    // query = await db_index.query(seed_insert.insert_into_give, [])
    // query = await db_index.query(seed_insert.insert_into_contains, [])
    // query = await db_index.query(seed_insert.insert_into_report, [])
    // query = await db_index.query(seed_insert.insert_into_recive, [])    





    // query = await db_index.crypto_query_wrapper(
    //     'INSERT INTO recive (userName, idmessages) VALUES ( $1, $2);', 
    //     [["username",  "PeroPeric"], ["idmessages", 0]],
    //     {
    //         "__username": "PeroPeric",
    //         "__table": "recive",
    //         "__key": "ovoSeNekakoPamti!"
    //     }
    // )

})();



// class DefaultDict {
        
//     constructor(defaultVal) {
//         return new Proxy({}, {
//             get: (target, name) => name in target ? target[name] : defaultVal
//         })
//     }

// }

// module.exports = class Queries {

//     static async getCategories() {
//         let query = await db_index.query('SELECT * FROM categories ORDER BY id', []);

//         let categories = [];
//         query.rows.forEach(e => {
//             categories.push(new Category(
//                 e.id, 
//                 e.name, 
//                 e.description, 
//                 e.seasonal  
//             ));    
//         });

//         this.categories = categories;

//         return categories;

//     }

//     static async getInventories() {

//         let inventories = new DefaultDict(undefined);

//         for (const category of this.categories) {
//             let query = await db_index.query("SELECT * FROM inventory WHERE categoryId = $1", [category.id]);

//             let inventory = [];
//             query.rows.forEach(e => {
                
//                 inventory.push(new Inventory(
//                     e.id, 
//                     e.name, 
//                     e.price, 
//                     e.categoryid, 
//                     e.imageurl,
//                     e.colors
//                 ));    

//             });
            
//             inventories[category.id] = inventory;

//         }

//         return inventories;
//     }

//     static async getInventoryElem(id) {

//         let query = await db_index.query("select inventory.*, \
//         categories.name as cname, description, seasonal as cid\
//         from inventory, categories\
//         where inventory.categoryid = categories.id and inventory.id =$1", [id]);
      
//         return query.rows[0];
//     }


// }


// ----------------------------------------------------

