-- MySQL Script generated by MySQL Workbench
-- 02/19/16 11:56:21
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema Car
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `Car` ;

-- -----------------------------------------------------
-- Schema Car
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Car` DEFAULT CHARACTER SET utf8 ;
USE `Car` ;

-- -----------------------------------------------------
-- Table `Car`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Car` (
  `CarID` INT NOT NULL AUTO_INCREMENT,
  `Car_colour` VARCHAR(45) NULL,
  `Car_name` VARCHAR(45) NOT NULL,
  `Car_Transmission` VARCHAR(45) NULL,
  `Car_Model` VARCHAR(45) NOT NULL,
  `Mfd_Date` DATE NULL,
  PRIMARY KEY (`CarID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Owner`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Owner` (
  `OwnerID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Occupation` VARCHAR(45) NULL,
  `Country` VARCHAR(45) NULL,
  PRIMARY KEY (`OwnerID`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;