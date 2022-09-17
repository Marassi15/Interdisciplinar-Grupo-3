const { post } = require('../app')
const db = require('./db')

const Processo = db.sequelize.define('Processo',{
    TITULO_PROC:{
        type: db.Sequelize.STRING
    }
})

post.sync({force:true}) 