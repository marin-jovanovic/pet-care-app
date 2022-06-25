const Category = require('../models/category');
const Inventory = require('../models/inventory');

const db_index = require('../db/index');

class DefaultDict {
        
    constructor(defaultVal) {
        return new Proxy({}, {
            get: (target, name) => name in target ? target[name] : defaultVal
        })
    }

}

module.exports = class Queries {

    static async getCategories() {
        let query = await db_index.query('SELECT * FROM categories ORDER BY id', []);

        let categories = [];
        query.rows.forEach(e => {
            categories.push(new Category(
                e.id, 
                e.name, 
                e.description, 
                e.seasonal  
            ));    
        });

        this.categories = categories;

        return categories;

    }

    static async getInventories() {

        let inventories = new DefaultDict(undefined);

        for (const category of this.categories) {
            let query = await db_index.query("SELECT * FROM inventory WHERE categoryId = $1", [category.id]);

            let inventory = [];
            query.rows.forEach(e => {
                
                inventory.push(new Inventory(
                    e.id, 
                    e.name, 
                    e.price, 
                    e.categoryid, 
                    e.imageurl,
                    e.colors
                ));    

            });
            
            inventories[category.id] = inventory;

        }

        return inventories;
    }

    static async getInventoryElem(id) {

        let query = await db_index.query("select inventory.*, \
        categories.name as cname, description, seasonal as cid\
        from inventory, categories\
        where inventory.categoryid = categories.id and inventory.id =$1", [id]);
      
        return query.rows[0];
    }


}