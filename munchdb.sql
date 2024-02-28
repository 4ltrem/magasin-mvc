USE master
GO
DROP DATABASE IF EXISTS munchdb;
CREATE DATABASE munchdb;
GO

USE munchdb;

--DROP TABLE IF EXISTS users
--CREATE TABLE users (
--	userid INT NOT NULL IDENTITY (1,1),
--	username VARCHAR(30) NOT NULL,
--	pwd VARCHAR(30) NOT NULL,

--	CONSTRAINT pk_userid PRIMARY KEY (userid)
--)

DROP TABLE IF EXISTS commandes
CREATE TABLE commandes (
	orderid INT NOT NULL IDENTITY (1,1),
	userid INT NOT NULL,
	prenom VARCHAR(50),
	nom VARCHAR(50),
	birthday DATE NOT NULL,
	numtele VARCHAR(12) NOT NULL,
	descCmd TEXT NOT NULL,
	address VARCHAR(50) NOT NULL,
	dateOfPurchase DATETIME NOT NULL DEFAULT current_timestamp,

	CONSTRAINT pk_commandes PRIMARY KEY (orderid, userid)
)



