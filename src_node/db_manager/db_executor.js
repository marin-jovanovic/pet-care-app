require('dotenv').config();
const {Pool} = require('pg');

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


module.exports = {
    get_pool, 
    query

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