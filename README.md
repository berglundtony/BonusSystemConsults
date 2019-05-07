1. Kör skriptet ConsultBonusSystemDb.sql i SQL Server Mangment Studio (Jag använde 2017 testade också i version 2014)
2. Kolla om connectionsträngen behöver ändras i web.config datasource=. betyder localhost. 
Har du Microsoft SQL Express-versionen måste du ändra DataSource till ./SQLEXPRESS .
connection string="data source=.;initial catalog=ConsultBonusSystemDB;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />

Lycka till!
