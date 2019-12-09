1. In the Web.config file you will find:

- connectionStrings tag
(You should specify the Server, User and Password);

example: 
	'  <connectionStrings>
	    <add name="EventContext" connectionString="Server=DESKTOP-2V6003F\MSSQLSERVER03;Database=myDataBase;User Id=sa; Password=qwerty123" providerName="System.Data.SqlClient" />
	  </connectionStrings>
	'

2. In Microsoft SQL Server

- user setup
 (You should create another user and password for SQL Server Authentication)
 '
  < ... "User Id=sa; Password=qwerty123" providerName="System.Data.SqlClient" />
 '
- database setup 
 (You should create database ex: "myDataBase")

 N! 
 Tables will auto create from EventInitialize.cs class!

