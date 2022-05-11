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
-- Table structure for table `hizmet`
--

DROP TABLE IF EXISTS `hizmet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hizmet` (
  `had` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `hno` int NOT NULL,
  `fiyat` float NOT NULL,
  PRIMARY KEY (`hno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hizmet`
--

LOCK TABLES `hizmet` WRITE;
/*!40000 ALTER TABLE `hizmet` DISABLE KEYS */;
INSERT INTO `hizmet` VALUES ('Gelin Başı',1,800),('Fön',2,120),('Ombre',3,500),('Saç Bakım',4,115),('Kaş Bakım',5,425),('Kirpik Bakım',6,290),('Microblading',7,1500),('Makyaj',8,250),('Jel Set',9,250),('Manikür',10,65),('Pedikür',11,75),('Tırnak Bakımı',12,250),('Bölgesel İncelme',13,250),('Solaryum',14,80),('Masaj',15,80),('Sauna',16,100),('Ağda',17,40),('Örgü',18,550),('Coloroskopi',19,80),('Tıraş',20,60),('Keratin Bakım',21,200),('Maşa',22,100),('Perma',23,500),('Röfle/Gölge',24,500),('Topuz',25,100),('Kalıcı Bakım',26,150),('Oje',27,15),('Natürel Bakım',28,35),('Spa',29,115),('Dermaterapi',30,300),('Hydrafacial',31,300),('Selülit Giderme',32,100),('Gençleştirme',33,200),('Anti-Aging',34,400),('Antioksidan Bakım',35,150),('Akne Bakımı',36,350),('Detoks',37,50),('Bal-Süt Bakımı',38,80),('Cilt Bakımı',39,200),('Deluxe Bakım',40,250),('Peeling',41,30),('Dudak Bakımı',42,15),('Göğüs Bakımı',43,120),('Göz Bakımı',44,100),('Havyar Bakım',45,150),('Holistik Bakım',46,230),('Kahve Bakımı',47,250),('Kavitasyon',48,150),('Kollajen Bakımı',49,80),('Lenf Drenaj',50,50),('Sıkılaştırıcı Bakım',51,100),('Nar Bakımı',52,30),('Yosun Battaniyesi',53,75),('Vitamin Bakımı',54,200),('Dövme',55,300),('Kulak Delimi',56,150),('Piercing',57,150),('Dermapen',58,350),('Dolgu',59,1000),('Maske',60,150),('Dermaroller',61,350),('Epilasyon',62,5),('Karboksi Terapi',63,200),('Leke Tedavisi',64,150),('Lipoliz',65,250),('Örümcek Ağı',66,1500),('PRP',67,350),('Somon DNA Aşısı',68,750),('TCA',69,500),('Mezoterapi',70,400),('Pilates',71,175),('Kilo Kontrolü',72,250),('Beslenme',73,500),('Vücut Analizi',74,50);
/*!40000 ALTER TABLE `hizmet` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-18 22:37:48
