// const sql_create_inventory = `CREATE TABLE inventory (
//     id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
//     name text NOT NULL UNIQUE,
//     price numeric NOT NULL,
//     categoryId int NOT NULL,
//     imageUrl text NOT NULL,
//     colors text NOT NULL
// )`;

// const sql_create_categories = `CREATE TABLE categories (
//     id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
//     name text NOT NULL UNIQUE,
//     description text NOT NULL,
//     seasonal text NOT NULL
// )`;

// const sql_insert_inventory = `INSERT INTO inventory (
//     name, price, categoryId, imageUrl, colors)
//     VALUES 
//     ('Tulip', 10, 1, 'https://i.imgur.com/Ttir6mp.jpg', 'white, red, yellow'),
//     ('Lavender', 15, 1, 'https://i.imgur.com/gH33WyT.jpg', 'blue'),
//     ('Fuchsia', 50, 1, 'https://i.imgur.com/s27QJBL.jpg', 'red-purple, white-purple, white-pink'),
//     ('Daisy', 30, 1, 'https://i.imgur.com/Agarl4v.jpg', 'white'),
//     ('Orchid', 90, 2, 'https://i.imgur.com/Dx4q8uE.jpg', 'green, white, purple'),
//     ('Fittonia', 80, 2, 'https://i.imgur.com/G9JfR3S.jpg', 'green, red'),
//     ('Showel', 150, 3, 'https://i.imgur.com/BcjgzeT.jpg', 'metal'),
//     ('Small showel', 50, 3, 'https://i.imgur.com/L80eL1e.jpg', 'metal'),
//     ('Rake', 100, 3, 'https://i.imgur.com/I5ctUan.jpg', 'metal'),
//     ('Tulip (1 kg)', 200, 4, 'https://i.imgur.com/WUYYzBG.jpg', 'white, red, yellow');
// `;

// const sql_insert_category = `INSERT INTO categories (name, description, seasonal) VALUES 
//     ('Flowers', 'Flowers make us smile', 'Yes'),
//     ('Indoor plants', 'Bring nature inside', 'No'),
//     ('Tools', 'Every gardener needs good tools', 'No'),
//     ('Seeds', 'Grow your own plants', 'No'),
//     ('Pots', 'Many sizes and styles', 'No'),
//     ('Fertilizers', 'Essential nutrients', 'No');
// `;


const db_index = require('./db_executor');
const seed_create = require('./seed_create');

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

