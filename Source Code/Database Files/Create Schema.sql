CREATE DATABASE  IF NOT EXISTS `OrganisationBitches` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `OrganisationBitches`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 10.1.1.91    Database: OrganisationBitches
-- ------------------------------------------------------
-- Server version	5.5.52-0+deb8u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `CurrentPerson`
--

DROP TABLE IF EXISTS `CurrentPerson`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CurrentPerson` (
  `PersonID` int(11) NOT NULL,
  PRIMARY KEY (`PersonID`),
  CONSTRAINT `fk_CurrentUser` FOREIGN KEY (`PersonID`) REFERENCES `Persons` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CurrentPerson`
--

LOCK TABLES `CurrentPerson` WRITE;
/*!40000 ALTER TABLE `CurrentPerson` DISABLE KEYS */;
INSERT INTO `CurrentPerson` VALUES (1);
/*!40000 ALTER TABLE `CurrentPerson` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Exercise`
--

DROP TABLE IF EXISTS `Exercise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Exercise` (
  `ID` int(11) NOT NULL,
  `ExerciseName` varchar(45) NOT NULL,
  `ExerciseTypeID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `Exercise_fk_etID` (`ExerciseTypeID`),
  CONSTRAINT `Exercise_fk_etID` FOREIGN KEY (`ExerciseTypeID`) REFERENCES `ExerciseType` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Exercise`
--

LOCK TABLES `Exercise` WRITE;
/*!40000 ALTER TABLE `Exercise` DISABLE KEYS */;
INSERT INTO `Exercise` VALUES (1,'Jogging',2);
/*!40000 ALTER TABLE `Exercise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ExerciseType`
--

DROP TABLE IF EXISTS `ExerciseType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ExerciseType` (
  `ID` int(11) NOT NULL,
  `TypeName` varchar(100) NOT NULL,
  `HasSets` bit(1) NOT NULL,
  `HasDistance` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ExerciseType`
--

LOCK TABLES `ExerciseType` WRITE;
/*!40000 ALTER TABLE `ExerciseType` DISABLE KEYS */;
INSERT INTO `ExerciseType` VALUES (1,'Resistance','',0),(2,'Cardio','\0',1),(3,'Flexibility','\0',0);
/*!40000 ALTER TABLE `ExerciseType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Persons`
--

DROP TABLE IF EXISTS `Persons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Persons` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `LastName` varchar(45) NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `UserLevelID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_UserLevel_idx` (`UserLevelID`),
  CONSTRAINT `fk_UserLevelsPersons` FOREIGN KEY (`UserLevelID`) REFERENCES `UserLevels` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `UserLevels`
--

DROP TABLE IF EXISTS `UserLevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `UserLevels` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserLevelName` varchar(45) NOT NULL,
  `CanViewAllUsersData` bit(1) NOT NULL,
  `CanEditAllUsersData` bit(1) NOT NULL,
  `HasSetupPrivileges` bit(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Persons`
--

LOCK TABLES `Persons` WRITE;
/*!40000 ALTER TABLE `Persons` DISABLE KEYS */;
INSERT INTO `Persons` VALUES (1,'Ford','Aaron');
/*!40000 ALTER TABLE `Persons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Results`
--

DROP TABLE IF EXISTS `Results`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Results` (
  `ID` int(11) NOT NULL,
  `ExerciseID` int(11) NOT NULL,
  `ExerciseDate` datetime NOT NULL,
  `EffortExerted` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `Results_fk_eID` (`ExerciseID`),
  CONSTRAINT `Results_fk_eID` FOREIGN KEY (`ExerciseID`) REFERENCES `Exercise` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Results`
--

LOCK TABLES `Results` WRITE;
/*!40000 ALTER TABLE `Results` DISABLE KEYS */;
/*!40000 ALTER TABLE `Results` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SetExercise`
--

DROP TABLE IF EXISTS `SetExercise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `SetExercise` (
  `ID` int(11) NOT NULL,
  `ExerciseName` varchar(45) NOT NULL,
  `ExerciseTypeID` int(11) NOT NULL,
  `RepCount` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ExerciseTypeID` (`ExerciseTypeID`),
  CONSTRAINT `SetExercise_ibfk_1` FOREIGN KEY (`ExerciseTypeID`) REFERENCES `ExerciseType` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SetExercise`
--

LOCK TABLES `SetExercise` WRITE;
/*!40000 ALTER TABLE `SetExercise` DISABLE KEYS */;
/*!40000 ALTER TABLE `SetExercise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SetResults`
--

DROP TABLE IF EXISTS `SetResults`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `SetResults` (
  `ID` int(11) NOT NULL,
  `SetExerciseID` int(11) NOT NULL,
  `SetNumber` int(11) NOT NULL,
  `Weight` double NOT NULL,
  `Repetitions` int(11) NOT NULL,
  `EffortExerted` int(11) NOT NULL,
  `Difficulty` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `Sets_fk_seID` (`SetExerciseID`),
  CONSTRAINT `Sets_fk_seID` FOREIGN KEY (`SetExerciseID`) REFERENCES `SetExercise` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SetResults`
--

LOCK TABLES `SetResults` WRITE;
/*!40000 ALTER TABLE `SetResults` DISABLE KEYS */;
/*!40000 ALTER TABLE `SetResults` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TimesheetEntries`
--

DROP TABLE IF EXISTS `TimesheetEntries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TimesheetEntries` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClockIn` datetime DEFAULT NULL,
  `ClockOut` datetime DEFAULT NULL,
  `UnpaidTime` bigint(20) DEFAULT NULL,
  `PaidTime` bigint(20) DEFAULT NULL,
  `PersonID` int(11) NOT NULL,
  `BreakStart` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_PersonsTimesheetEntries` (`PersonID`),
  CONSTRAINT `fk_PersonsTimesheetEntries` FOREIGN KEY (`PersonID`) REFERENCES `Persons` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TimesheetEntries`
--

LOCK TABLES `TimesheetEntries` WRITE;
/*!40000 ALTER TABLE `TimesheetEntries` DISABLE KEYS */;
/*!40000 ALTER TABLE `TimesheetEntries` ENABLE KEYS */;
UNLOCK TABLES;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

--
-- Table structure for table `RosterEntries`
--

DROP TABLE IF EXISTS `RosterEntries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `RosterEntries` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RosterID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `EntryDate` date NOT NULL,
  `StartTime` time NOT NULL,
  `EndTime` time NOT NULL,
  `UnpaidTimeTicks` bigint(20) NOT NULL,
  `PaidTimeTicks` bigint(20) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_RostersRosterEntries_idx` (`RosterID`),
  KEY `fk_PersonsRosterEntries_idx` (`UserID`),
  CONSTRAINT `fk_RostersRosterEntries` FOREIGN KEY (`RosterID`) REFERENCES `Rosters` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_PersonsRosterEntries` FOREIGN KEY (`UserID`) REFERENCES `Persons` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Rosters`
--

DROP TABLE IF EXISTS `Rosters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Rosters` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `StartDate` date NOT NULL,
  `EndDate` date NOT NULL,
  `AllocatedPermanentHours` double,
  `AllocatedCasualHours` double,
  `AllocatedHours` double,
  `TotalHours` double,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `PersonEmploymentLevels`
--

DROP TABLE IF EXISTS `PersonEmploymentLevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `PersonEmploymentLevels` (
  `PersonID` int(11) NOT NULL,
  `EmploymentLevelID` int(11) NOT NULL,
  PRIMARY KEY (`PersonID`),
  KEY `fk_EmployLvlPersonEmployLvl_idx` (`EmploymentLevelID`),
  CONSTRAINT `fk_PersonPersonEmployLvl` FOREIGN KEY (`PersonID`) REFERENCES `Persons` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_EmployLvlPersonEmployLvl` FOREIGN KEY (`EmploymentLevelID`) REFERENCES `EmploymentLevels` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `EmploymentLevels`
--

DROP TABLE IF EXISTS `EmploymentLevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `EmploymentLevels` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EmploymentLevelName` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmploymentLevels`
--

LOCK TABLES `EmploymentLevels` WRITE;
/*!40000 ALTER TABLE `EmploymentLevels` DISABLE KEYS */;
INSERT INTO `EmploymentLevels` VALUES (1,'Permanent'),(2,'Casual');
/*!40000 ALTER TABLE `EmploymentLevels` ENABLE KEYS */;
UNLOCK TABLES;

-- Dump completed on 2016-11-10 13:24:22
