SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema University
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `University` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `University` ;

-- -----------------------------------------------------
-- Table `University`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Faculties` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Students` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `faculty_id` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `faculty_id_idx` (`faculty_id` ASC),
  CONSTRAINT `FK_Students_Faculties`
    FOREIGN KEY (`faculty_id`)
    REFERENCES `University`.`Faculties` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Departments` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `faculty_id` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `faculty_id_idx` (`faculty_id` ASC),
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`faculty_id`)
    REFERENCES `University`.`Faculties` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Professors` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `department_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `department_id_idx` (`department_id` ASC),
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`department_id`)
    REFERENCES `University`.`Departments` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Courses` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `department_id` INT NOT NULL,
  `professor_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `department_id_idx` (`department_id` ASC),
  INDEX `professor_id_idx` (`professor_id` ASC),
  CONSTRAINT `FK_Courses_Departments`
    FOREIGN KEY (`department_id`)
    REFERENCES `University`.`Departments` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Courses_Professors`
    FOREIGN KEY (`professor_id`)
    REFERENCES `University`.`Professors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Titles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`StudentsCourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`StudentsCourses` (
  `student_id` INT NOT NULL,
  `course_id` INT NOT NULL,
  PRIMARY KEY (`student_id`, `course_id`),
  INDEX `course_id_idx` (`course_id` ASC),
  CONSTRAINT `FK_StudentsCourses_Students`
    FOREIGN KEY (`student_id`)
    REFERENCES `University`.`Students` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_StudentsCourses_Courses`
    FOREIGN KEY (`course_id`)
    REFERENCES `University`.`Courses` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`ProfessorTitles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`ProfessorTitles` (
  `professor_id` INT NOT NULL,
  `title_id` INT NOT NULL,
  PRIMARY KEY (`professor_id`, `title_id`),
  INDEX `title_id_idx` (`title_id` ASC),
  CONSTRAINT `FK_ProfessorTitles_Professors`
    FOREIGN KEY (`professor_id`)
    REFERENCES `University`.`Professors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProfessorTitles_Titles`
    FOREIGN KEY (`title_id`)
    REFERENCES `University`.`Titles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
