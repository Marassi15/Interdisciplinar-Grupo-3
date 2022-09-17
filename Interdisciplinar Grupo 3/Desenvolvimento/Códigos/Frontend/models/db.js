const Sequelize = require('sequelize')

//Configuranção com o BD e utilizar o sequelize
const sequelize = new Sequelize('softwaremedicao','root','mengao2016',{
    host: "localhost",
    dialect: 'mysql'
})

module.exports = {
    Sequelize: Sequelize,
    sequelize: sequelize
}