-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: guzellik
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `calisan`
--

DROP TABLE IF EXISTS `calisan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `calisan` (
  `ad` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `soyad` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `cid` int NOT NULL,
  `dgunu` datetime DEFAULT NULL,
  `adres` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `cinsiyet` varchar(1) DEFAULT NULL,
  `maas` float NOT NULL,
  PRIMARY KEY (`cid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calisan`
--

LOCK TABLES `calisan` WRITE;
/*!40000 ALTER TABLE `calisan` DISABLE KEYS */;
INSERT INTO `calisan` VALUES ('Mustafa','Aydın',1,'1993-06-19 00:00:00','asd','e',10240),('Muhammed Ali','Soylu',2,'1990-03-09 00:00:00','qwe','e',4000),('Duygu','Erduran',3,'1995-12-10 00:00:00','zxc','k',6400),('Berfin','Toktaş',4,'1995-01-04 00:00:00','rty','k',6400),('Besik','Sharashidze',5,'1985-09-18 00:00:00','fgh','e',2500),('Fatih','Yılmaz',6,'1996-03-05 00:00:00','vbn','e',2500);
/*!40000 ALTER TABLE `calisan` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-18 22:37:49
