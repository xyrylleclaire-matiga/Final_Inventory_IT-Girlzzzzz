-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 09, 2025 at 04:21 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_inventorysystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `approvals`
--

CREATE TABLE `approvals` (
  `ApprovalID` int(11) NOT NULL,
  `RequestID` int(11) NOT NULL,
  `ApprovedBy` int(10) UNSIGNED DEFAULT NULL,
  `Status` enum('Pending','Approved','Rejected') DEFAULT 'Pending',
  `Remarks` text DEFAULT NULL,
  `ActionDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `incoming_items`
--

CREATE TABLE `incoming_items` (
  `IncomingID` int(11) NOT NULL,
  `TransactionID` int(11) NOT NULL,
  `productCode` int(50) UNSIGNED NOT NULL,
  `QuantityReceived` int(11) NOT NULL,
  `DetailID` int(11) UNSIGNED NOT NULL,
  `QCStatus` enum('Pending','Approved','Rejected') DEFAULT 'Pending',
  `QuantityApproved` int(11) DEFAULT 0,
  `Notes` varchar(255) DEFAULT NULL,
  `ReceivedDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `incoming_items`
--

INSERT INTO `incoming_items` (`IncomingID`, `TransactionID`, `productCode`, `QuantityReceived`, `DetailID`, `QCStatus`, `QuantityApproved`, `Notes`, `ReceivedDate`) VALUES
(3, 21, 1001, 111, 3, '', 11, 'Poor Quality', '2025-11-09 15:29:50'),
(4, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 15:52:06'),
(5, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 15:54:19'),
(6, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 15:54:23'),
(7, 25, 1001, 121, 7, '', 20, 'Wrong Specifications', '2025-11-09 15:55:19'),
(8, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 15:57:41'),
(9, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 15:59:34'),
(10, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:00:51'),
(11, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:03:27'),
(12, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:05:17'),
(13, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:10:15'),
(14, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:10:26'),
(15, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:12:13'),
(16, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:19:35'),
(17, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 16:22:35'),
(18, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:31:21'),
(19, 26, 1001, 121, 8, '', 110, 'Damaged/Defective', '2025-11-09 17:32:47'),
(20, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:33:34'),
(21, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:35:34'),
(22, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:38:45'),
(23, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:40:58'),
(24, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:44:01'),
(25, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:47:15'),
(26, 23, 1001, 1, 5, 'Approved', 1, NULL, '2025-11-09 17:54:56'),
(30, 21, 1001, 111, 3, '', 100, 'Rejected: 11 (Quality Issues)', '2025-11-09 22:07:39'),
(33, 23, 1001, 1, 5, '', 1, 'Fully received and approved', '2025-11-09 22:17:36'),
(34, 25, 1001, 121, 7, '', 20, 'Rejected: 101 (Quality Issues)', '2025-11-09 22:18:36'),
(36, 26, 1001, 121, 8, '', 100, 'Rejected: 21 (Damaged)', '2025-11-09 22:33:40'),
(37, 34, 1001, 10, 11, '', 5, 'Rejected: 5 (Incomplete Order)', '2025-11-09 22:37:31'),
(38, 36, 1001, 5, 12, '', 3, 'Rejected: 2 (Quality Issues)', '2025-11-09 22:38:27'),
(39, 31, 1001, 1221, 9, '', 10, 'Rejected: 1211 (Quality Issues)', '2025-11-09 22:51:22'),
(40, 32, 1001, 100, 10, '', 50, 'Rejected: 50 (Expired)', '2025-11-09 22:55:25');

-- --------------------------------------------------------

--
-- Table structure for table `overallproduct`
--

CREATE TABLE `overallproduct` (
  `productCode` int(50) UNSIGNED NOT NULL,
  `ProductName` varchar(255) NOT NULL,
  `Category` enum('School Uniform','PE Uniform','Corporate Attire','Accessories') NOT NULL,
  `total_stock` int(11) DEFAULT 0,
  `Status` enum('Active','Inactive') DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `overallproduct`
--

INSERT INTO `overallproduct` (`productCode`, `ProductName`, `Category`, `total_stock`, `Status`) VALUES
(1001, 'Blouse', 'School Uniform', 294, 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `productgroups`
--

CREATE TABLE `productgroups` (
  `ProductGroupID` int(11) NOT NULL,
  `GroupName` enum('Accessories','Uniforms') NOT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `productgroups`
--

INSERT INTO `productgroups` (`ProductGroupID`, `GroupName`, `Description`) VALUES
(1, '', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` int(10) UNSIGNED NOT NULL,
  `ProductGroupID` int(11) DEFAULT NULL,
  `productCode` int(50) UNSIGNED NOT NULL,
  `ProductName` varchar(255) NOT NULL,
  `gender` enum('Female','Male','Unisex') NOT NULL,
  `Size` varchar(50) NOT NULL,
  `ProductType` enum('Set','AlaCarte') NOT NULL DEFAULT 'AlaCarte',
  `UnitPrice` decimal(10,2) DEFAULT 0.00,
  `Unit` varchar(100) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT current_timestamp(),
  `UpdatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Category` enum('School Uniform','PE Uniform','Corporate Attire','Accessories') NOT NULL,
  `Level` enum('Kindergarten','Elementary','Integrated High School','College') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductID`, `ProductGroupID`, `productCode`, `ProductName`, `gender`, `Size`, `ProductType`, `UnitPrice`, `Unit`, `CreatedAt`, `UpdatedAt`, `Category`, `Level`) VALUES
(1, 1, 1001, 'Blouse', 'Female', '', 'AlaCarte', 450.00, 'Small', '2025-11-08 02:05:13', '2025-11-08 02:26:56', 'School Uniform', 'Kindergarten'),
(2, 1, 1001, 'Blouse', 'Female', '', 'AlaCarte', 450.00, 'Small', '2025-11-08 02:20:36', '2025-11-08 03:16:47', 'School Uniform', 'Kindergarten'),
(4, 1, 1001, 'Blouse', 'Female', '', 'AlaCarte', 450.00, 'Small', '2025-11-08 02:34:19', '2025-11-08 03:16:50', 'School Uniform', 'Kindergarten'),
(6, 1, 1001, 'Blouse', 'Female', '', 'AlaCarte', 450.00, 'Small', '2025-11-08 02:50:55', '2025-11-08 03:16:52', 'School Uniform', 'Kindergarten'),
(138, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(139, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(140, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(141, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(142, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(143, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(144, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(145, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(146, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(147, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(148, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(149, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(150, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(151, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(152, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(153, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(154, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(155, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(156, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(157, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(158, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(159, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(160, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(161, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(162, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(163, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(164, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(165, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(166, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(167, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(168, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(169, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(170, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(171, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(172, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(173, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(174, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(175, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(176, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(177, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(178, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(179, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(180, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(181, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(182, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(183, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(184, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(185, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(186, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(187, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(188, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(189, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(190, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(191, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(192, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(193, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(194, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(195, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(196, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(197, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(198, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(199, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(200, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(201, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(202, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(203, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(204, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(205, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(206, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(207, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(208, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(209, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(210, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(211, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(212, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(213, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(214, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(215, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(216, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(217, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(218, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(219, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(220, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(221, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(222, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(223, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(224, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(225, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(226, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(227, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(228, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(229, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(230, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(231, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(232, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(233, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(234, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(235, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(236, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(237, NULL, 1001, 'Blouse', 'Male', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:07:39', '2025-11-09 22:07:39', 'School Uniform', 'Integrated High School'),
(238, NULL, 1001, 'Test Blouse', 'Female', 'M', 'AlaCarte', 0.00, NULL, '2025-11-09 22:11:12', '2025-11-09 22:11:12', 'School Uniform', ''),
(241, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:17:36', '2025-11-09 22:17:36', 'School Uniform', 'Integrated High School'),
(242, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(243, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(244, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(245, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(246, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(247, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(248, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(249, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(250, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(251, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(252, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(253, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(254, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(255, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(256, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(257, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(258, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(259, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(260, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(261, NULL, 1001, 'Blouse', 'Female', 'XSmall', 'AlaCarte', 0.00, NULL, '2025-11-09 22:18:36', '2025-11-09 22:18:36', 'School Uniform', 'Elementary'),
(362, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(363, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(364, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(365, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(366, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(367, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(368, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(369, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(370, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(371, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(372, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(373, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(374, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(375, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(376, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(377, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(378, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(379, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(380, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(381, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(382, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(383, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(384, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(385, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(386, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(387, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(388, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(389, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(390, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(391, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(392, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(393, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(394, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(395, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(396, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(397, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(398, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(399, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(400, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(401, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(402, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(403, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(404, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(405, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(406, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(407, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(408, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(409, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(410, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(411, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(412, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(413, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(414, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(415, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(416, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(417, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(418, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(419, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(420, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(421, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(422, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(423, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(424, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(425, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(426, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(427, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(428, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(429, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(430, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(431, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(432, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(433, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(434, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(435, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(436, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(437, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(438, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(439, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(440, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(441, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(442, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(443, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(444, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(445, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(446, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(447, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(448, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(449, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(450, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(451, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(452, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(453, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(454, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(455, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(456, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(457, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(458, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(459, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(460, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(461, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:33:40', '2025-11-09 22:33:40', 'School Uniform', 'College'),
(462, NULL, 1001, 'Blouse', 'Unisex', 'XLarge', 'AlaCarte', 0.00, NULL, '2025-11-09 22:37:31', '2025-11-09 22:37:31', 'School Uniform', 'Integrated High School'),
(463, NULL, 1001, 'Blouse', 'Unisex', 'XLarge', 'AlaCarte', 0.00, NULL, '2025-11-09 22:37:31', '2025-11-09 22:37:31', 'School Uniform', 'Integrated High School'),
(464, NULL, 1001, 'Blouse', 'Unisex', 'XLarge', 'AlaCarte', 0.00, NULL, '2025-11-09 22:37:31', '2025-11-09 22:37:31', 'School Uniform', 'Integrated High School'),
(465, NULL, 1001, 'Blouse', 'Unisex', 'XLarge', 'AlaCarte', 0.00, NULL, '2025-11-09 22:37:31', '2025-11-09 22:37:31', 'School Uniform', 'Integrated High School'),
(466, NULL, 1001, 'Blouse', 'Unisex', 'XLarge', 'AlaCarte', 0.00, NULL, '2025-11-09 22:37:31', '2025-11-09 22:37:31', 'School Uniform', 'Integrated High School'),
(467, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:38:27', '2025-11-09 22:38:27', 'School Uniform', 'Elementary'),
(468, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:38:27', '2025-11-09 22:38:27', 'School Uniform', 'Elementary'),
(469, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:38:27', '2025-11-09 22:38:27', 'School Uniform', 'Elementary'),
(470, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(471, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(472, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(473, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(474, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(475, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(476, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(477, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(478, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(479, NULL, 1001, 'Blouse', 'Unisex', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:51:22', '2025-11-09 22:51:22', 'School Uniform', 'Integrated High School'),
(480, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(481, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(482, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(483, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(484, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(485, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(486, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(487, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(488, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(489, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(490, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(491, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(492, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(493, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(494, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(495, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(496, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(497, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(498, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(499, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(500, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(501, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(502, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(503, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(504, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(505, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(506, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(507, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(508, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(509, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(510, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(511, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(512, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(513, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(514, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(515, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(516, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(517, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(518, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(519, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(520, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(521, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(522, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(523, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(524, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(525, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(526, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(527, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(528, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary'),
(529, NULL, 1001, 'Blouse', 'Female', 'Small', 'AlaCarte', 0.00, NULL, '2025-11-09 22:55:25', '2025-11-09 22:55:25', 'School Uniform', 'Elementary');

-- --------------------------------------------------------

--
-- Table structure for table `purchase_details`
--

CREATE TABLE `purchase_details` (
  `DetailID` int(11) UNSIGNED NOT NULL,
  `TransactionID` int(11) NOT NULL,
  `productCode` int(50) UNSIGNED NOT NULL,
  `Size` varchar(100) NOT NULL,
  `Level` varchar(50) NOT NULL,
  `Gender` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL DEFAULT 0,
  `OrderType` enum('AlaCarte','Set') NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL DEFAULT 0.00,
  `TotalPrice` decimal(10,2) NOT NULL DEFAULT 0.00,
  `Remarks` varchar(255) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT current_timestamp(),
  `UpdatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `purchase_details`
--

INSERT INTO `purchase_details` (`DetailID`, `TransactionID`, `productCode`, `Size`, `Level`, `Gender`, `Quantity`, `OrderType`, `UnitPrice`, `TotalPrice`, `Remarks`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 19, 1001, 'Small', 'Elementary', 'Female', 11, 'AlaCarte', 10.00, 110.00, NULL, '2025-11-09 14:24:34', '2025-11-09 14:24:34'),
(2, 20, 1001, 'XSmall', 'Elementary', 'Unisex', 1, 'AlaCarte', 10.00, 10.00, NULL, '2025-11-09 14:26:02', '2025-11-09 14:26:02'),
(3, 21, 1001, 'XSmall', 'Integrated High School', 'Male', 111, 'AlaCarte', 10.00, 1110.00, NULL, '2025-11-09 14:30:06', '2025-11-09 14:30:06'),
(4, 22, 1001, 'XSmall', 'Elementary', 'Female', 111, 'AlaCarte', 120.00, 13320.00, NULL, '2025-11-09 14:31:55', '2025-11-09 14:31:55'),
(5, 23, 1001, 'XSmall', 'Integrated High School', 'Female', 1, 'AlaCarte', 10.00, 10.00, NULL, '2025-11-09 14:34:15', '2025-11-09 14:34:15'),
(6, 24, 1001, 'Small', 'Integrated High School', 'Unisex', 1111, 'AlaCarte', 120.00, 133320.00, NULL, '2025-11-09 14:41:03', '2025-11-09 14:41:03'),
(7, 25, 1001, 'XSmall', 'Elementary', 'Female', 121, 'AlaCarte', 1000.00, 121000.00, NULL, '2025-11-09 15:42:09', '2025-11-09 15:42:09'),
(8, 26, 1001, 'Small', 'College', 'Unisex', 121, 'Set', 1000.00, 121000.00, NULL, '2025-11-09 17:32:10', '2025-11-09 17:32:10'),
(9, 31, 1001, 'Small', 'Integrated High School', 'Unisex', 1221, 'AlaCarte', 1000.00, 1221000.00, NULL, '2025-11-09 22:21:19', '2025-11-09 22:21:19'),
(10, 32, 1001, 'Small', 'Elementary', 'Female', 100, 'AlaCarte', 1200.00, 120000.00, NULL, '2025-11-09 22:30:02', '2025-11-09 22:30:02'),
(11, 34, 1001, 'XLarge', 'Integrated High School', 'Unisex', 10, 'Set', 1000.00, 10000.00, NULL, '2025-11-09 22:34:23', '2025-11-09 22:34:23'),
(12, 36, 1001, 'Small', 'Elementary', 'Unisex', 5, 'Set', 10000.00, 50000.00, NULL, '2025-11-09 22:38:02', '2025-11-09 22:38:02'),
(13, 40, 1001, 'XSmall', 'Kindergarten', 'Male', 101, 'AlaCarte', 1000.00, 101000.00, NULL, '2025-11-09 23:00:51', '2025-11-09 23:00:51');

--
-- Triggers `purchase_details`
--
DELIMITER $$
CREATE TRIGGER `trg_calculate_totalprice` BEFORE INSERT ON `purchase_details` FOR EACH ROW BEGIN
    SET NEW.TotalPrice = NEW.Quantity * NEW.UnitPrice;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `requestitems`
--

CREATE TABLE `requestitems` (
  `RequestItemID` int(11) NOT NULL,
  `RequestID` int(11) NOT NULL,
  `ProductID` int(10) UNSIGNED NOT NULL,
  `Quantity` int(11) DEFAULT 0,
  `UnitPrice` decimal(10,2) DEFAULT 0.00,
  `SubTotal` decimal(10,2) GENERATED ALWAYS AS (`Quantity` * `UnitPrice`) STORED
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `requestitems`
--

INSERT INTO `requestitems` (`RequestItemID`, `RequestID`, `ProductID`, `Quantity`, `UnitPrice`) VALUES
(1, 1, 1, 10, 520.00);

-- --------------------------------------------------------

--
-- Table structure for table `requests`
--

CREATE TABLE `requests` (
  `RequestID` int(11) NOT NULL,
  `RequestedBy` int(11) NOT NULL,
  `RequestType` enum('PullOut','Issuance','Replenish') NOT NULL,
  `Reason` varchar(255) DEFAULT NULL,
  `Status` enum('Pending','Approved','Rejected','Completed') DEFAULT 'Pending',
  `TotalAmount` decimal(10,2) DEFAULT 0.00,
  `RequestDate` datetime DEFAULT current_timestamp(),
  `UpdatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `requests`
--

INSERT INTO `requests` (`RequestID`, `RequestedBy`, `RequestType`, `Reason`, `Status`, `TotalAmount`, `RequestDate`, `UpdatedAt`) VALUES
(1, 1000002, 'Issuance', 'Secret', 'Pending', 15000.00, '2025-11-08 09:35:49', '2025-11-08 09:36:01');

-- --------------------------------------------------------

--
-- Table structure for table `stock_audit`
--

CREATE TABLE `stock_audit` (
  `audit_id` int(11) NOT NULL,
  `uniform_id` int(11) NOT NULL,
  `counted_quantity` int(11) NOT NULL,
  `system_quantity` int(11) NOT NULL,
  `variance` int(11) GENERATED ALWAYS AS (`counted_quantity` - `system_quantity`) STORED,
  `audit_date` datetime DEFAULT current_timestamp(),
  `conducted_by` int(11) DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbladmin_users`
--

CREATE TABLE `tbladmin_users` (
  `admin_id` int(10) UNSIGNED NOT NULL,
  `username` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `Middle_Name` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `role` enum('Super Admin','Staff') NOT NULL DEFAULT 'Staff',
  `Date_Added` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Status` enum('Active','Inactive','Deactivated') NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbladmin_users`
--

INSERT INTO `tbladmin_users` (`admin_id`, `username`, `LastName`, `FirstName`, `Middle_Name`, `Password`, `role`, `Date_Added`, `Status`) VALUES
(11111111, 'Super_Admin', 'Admin', 'Super', 'S', 'ADMIN', 'Super Admin', '2025-11-06 19:56:55', 'Active'),
(12344321, 'Marasigan', 'Morales', 'Reynaldo', 'M', 'REYNALDO', 'Staff', '2025-11-09 11:37:50', 'Deactivated'),
(67899876, 'Morales', 'Morales', 'Maria Dionesia', 'L', 'DIONESIA', 'Super Admin', '2025-11-06 19:56:55', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `tbltransactions`
--

CREATE TABLE `tbltransactions` (
  `TransactionID` int(11) NOT NULL,
  `TransactionType` enum('Purchase Order','Issuance','Request','Receiving') NOT NULL,
  `ItemType` enum('Uniform','Accessory') NOT NULL,
  `productCode` int(50) DEFAULT NULL,
  `Quantity` int(11) NOT NULL,
  `TransactionDate` datetime DEFAULT current_timestamp(),
  `ReferenceID` int(11) DEFAULT NULL,
  `ProcessedBy` int(10) UNSIGNED DEFAULT NULL,
  `ApprovedBy` int(10) UNSIGNED DEFAULT NULL,
  `Status` enum('Pending','Approved','Rejected','Received') NOT NULL,
  `Remarks` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbltransactions`
--

INSERT INTO `tbltransactions` (`TransactionID`, `TransactionType`, `ItemType`, `productCode`, `Quantity`, `TransactionDate`, `ReferenceID`, `ProcessedBy`, `ApprovedBy`, `Status`, `Remarks`) VALUES
(4, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(5, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(6, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(7, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(8, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(9, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(10, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(11, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(12, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(13, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(14, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(15, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(16, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(17, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(18, '', 'Uniform', NULL, 0, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(19, '', 'Uniform', NULL, 11, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Rejected', NULL),
(20, '', 'Uniform', NULL, 1, '2025-11-09 00:00:00', NULL, 67899876, 67899876, 'Approved', NULL),
(21, 'Purchase Order', 'Uniform', NULL, 111, '2025-11-09 00:00:00', NULL, 67899876, 67899876, '', ' | Received on 2025-11-09 22:07:39 by Admin ID: 67899876'),
(22, 'Issuance', 'Uniform', NULL, 111, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Pending', NULL),
(23, 'Purchase Order', 'Uniform', NULL, 1, '2025-11-09 00:00:00', NULL, 67899876, 67899876, '', ' | Received on 2025-11-09 22:17:36 by Admin ID: 67899876'),
(24, 'Purchase Order', 'Accessory', NULL, 1111, '2025-11-09 00:00:00', NULL, 67899876, NULL, 'Rejected', NULL),
(25, 'Purchase Order', 'Uniform', NULL, 121, '2025-11-09 00:00:00', NULL, 67899876, 67899876, '', ' | Received on 2025-11-09 22:18:36 by Admin ID: 67899876'),
(26, 'Purchase Order', 'Uniform', NULL, 121, '2025-11-09 00:00:00', NULL, 67899876, 67899876, '', ' | Received on 2025-11-09 22:33:40 by Admin ID: 67899876'),
(28, 'Receiving', 'Uniform', NULL, 100, '2025-11-09 22:07:39', 21, 67899876, NULL, '', 'Product 1001: Approved=100, Rejected=11 (Quality Issues)'),
(29, 'Receiving', 'Uniform', NULL, 1, '2025-11-09 22:17:36', 23, 67899876, NULL, '', 'Order fully received and processed.'),
(30, 'Receiving', 'Uniform', NULL, 20, '2025-11-09 22:18:36', 25, 67899876, NULL, '', 'Product 1001: Approved=20, Rejected=101 (Quality Issues)'),
(31, 'Purchase Order', 'Uniform', NULL, 1221, '2025-11-09 00:00:00', NULL, 67899876, 67899876, 'Received', ' | Received on 2025-11-09 22:51:22 by Admin ID: 67899876'),
(32, 'Purchase Order', 'Uniform', NULL, 100, '2025-11-09 00:00:00', NULL, 67899876, 67899876, 'Received', ' | Received on 2025-11-09 22:55:25 by Admin ID: 67899876'),
(33, 'Receiving', 'Uniform', NULL, 100, '2025-11-09 22:33:40', 26, 67899876, 67899876, '', 'Product 1001: Approved=100, Rejected=21 (Damaged)'),
(34, 'Purchase Order', 'Accessory', NULL, 10, '2025-11-09 00:00:00', NULL, 67899876, 67899876, 'Received', ' | Received on 2025-11-09 22:37:31 by Admin ID: 67899876'),
(35, 'Receiving', 'Accessory', NULL, 5, '2025-11-09 22:37:31', 34, 67899876, 67899876, '', 'Product 1001: Approved=5, Rejected=5 (Incomplete Order)'),
(36, 'Purchase Order', 'Uniform', NULL, 5, '2025-11-09 00:00:00', NULL, 67899876, 67899876, 'Received', ' | Received on 2025-11-09 22:38:27 by Admin ID: 67899876'),
(37, 'Receiving', 'Uniform', NULL, 3, '2025-11-09 22:38:27', 36, 67899876, 67899876, '', 'Product 1001: Approved=3, Rejected=2 (Quality Issues)'),
(38, 'Receiving', 'Uniform', NULL, 10, '2025-11-09 22:51:22', 31, 67899876, 67899876, '', 'Product 1001: Approved=10, Rejected=1211 (Quality Issues)'),
(39, 'Receiving', 'Uniform', NULL, 50, '2025-11-09 22:55:25', 32, 67899876, 67899876, '', 'Product 1001: Approved=50, Rejected=50 (Expired)'),
(40, 'Purchase Order', 'Uniform', NULL, 101, '2025-11-09 00:00:00', NULL, 67899876, 67899876, 'Approved', NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `approvals`
--
ALTER TABLE `approvals`
  ADD PRIMARY KEY (`ApprovalID`),
  ADD KEY `RequestID` (`RequestID`),
  ADD KEY `ApprovedBy` (`ApprovedBy`);

--
-- Indexes for table `incoming_items`
--
ALTER TABLE `incoming_items`
  ADD PRIMARY KEY (`IncomingID`),
  ADD KEY `TransactionID` (`TransactionID`),
  ADD KEY `productCode` (`productCode`),
  ADD KEY `DetailID` (`DetailID`);

--
-- Indexes for table `overallproduct`
--
ALTER TABLE `overallproduct`
  ADD PRIMARY KEY (`productCode`);

--
-- Indexes for table `productgroups`
--
ALTER TABLE `productgroups`
  ADD PRIMARY KEY (`ProductGroupID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`),
  ADD KEY `ProductGroupID` (`ProductGroupID`),
  ADD KEY `productCode` (`productCode`);

--
-- Indexes for table `purchase_details`
--
ALTER TABLE `purchase_details`
  ADD PRIMARY KEY (`DetailID`),
  ADD KEY `fk_transaction` (`TransactionID`),
  ADD KEY `productCode` (`productCode`);

--
-- Indexes for table `requestitems`
--
ALTER TABLE `requestitems`
  ADD PRIMARY KEY (`RequestItemID`),
  ADD KEY `RequestID` (`RequestID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- Indexes for table `requests`
--
ALTER TABLE `requests`
  ADD PRIMARY KEY (`RequestID`),
  ADD KEY `RequestedBy` (`RequestedBy`);

--
-- Indexes for table `stock_audit`
--
ALTER TABLE `stock_audit`
  ADD PRIMARY KEY (`audit_id`),
  ADD KEY `conducted_by` (`conducted_by`),
  ADD KEY `uniform_id` (`uniform_id`);

--
-- Indexes for table `tbladmin_users`
--
ALTER TABLE `tbladmin_users`
  ADD PRIMARY KEY (`admin_id`);

--
-- Indexes for table `tbltransactions`
--
ALTER TABLE `tbltransactions`
  ADD PRIMARY KEY (`TransactionID`),
  ADD KEY `ProcessedBy` (`ProcessedBy`),
  ADD KEY `ApprovedBy` (`ApprovedBy`),
  ADD KEY `idx_ItemType_ItemID` (`ItemType`,`productCode`),
  ADD KEY `idx_TransactionType` (`TransactionType`),
  ADD KEY `idx_TransactionDate` (`TransactionDate`),
  ADD KEY `fk_productcode` (`productCode`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `approvals`
--
ALTER TABLE `approvals`
  MODIFY `ApprovalID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `incoming_items`
--
ALTER TABLE `incoming_items`
  MODIFY `IncomingID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `overallproduct`
--
ALTER TABLE `overallproduct`
  MODIFY `productCode` int(50) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1002;

--
-- AUTO_INCREMENT for table `productgroups`
--
ALTER TABLE `productgroups`
  MODIFY `ProductGroupID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=530;

--
-- AUTO_INCREMENT for table `purchase_details`
--
ALTER TABLE `purchase_details`
  MODIFY `DetailID` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `requestitems`
--
ALTER TABLE `requestitems`
  MODIFY `RequestItemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `requests`
--
ALTER TABLE `requests`
  MODIFY `RequestID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `stock_audit`
--
ALTER TABLE `stock_audit`
  MODIFY `audit_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbladmin_users`
--
ALTER TABLE `tbladmin_users`
  MODIFY `admin_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67899877;

--
-- AUTO_INCREMENT for table `tbltransactions`
--
ALTER TABLE `tbltransactions`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `approvals`
--
ALTER TABLE `approvals`
  ADD CONSTRAINT `fk_approvals_admin` FOREIGN KEY (`ApprovedBy`) REFERENCES `tbladmin_users` (`admin_id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `incoming_items`
--
ALTER TABLE `incoming_items`
  ADD CONSTRAINT `incoming_items_ibfk_1` FOREIGN KEY (`TransactionID`) REFERENCES `tbltransactions` (`TransactionID`),
  ADD CONSTRAINT `incoming_items_ibfk_2` FOREIGN KEY (`productCode`) REFERENCES `overallproduct` (`productCode`),
  ADD CONSTRAINT `incoming_items_ibfk_3` FOREIGN KEY (`DetailID`) REFERENCES `purchase_details` (`DetailID`);

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`ProductGroupID`) REFERENCES `productgroups` (`ProductGroupID`),
  ADD CONSTRAINT `products_ibfk_2` FOREIGN KEY (`productCode`) REFERENCES `overallproduct` (`productCode`);

--
-- Constraints for table `purchase_details`
--
ALTER TABLE `purchase_details`
  ADD CONSTRAINT `fk_product_code_final` FOREIGN KEY (`productCode`) REFERENCES `overallproduct` (`productCode`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_transaction` FOREIGN KEY (`TransactionID`) REFERENCES `tbltransactions` (`TransactionID`) ON DELETE CASCADE,
  ADD CONSTRAINT `purchase_details_ibfk_1` FOREIGN KEY (`productCode`) REFERENCES `overallproduct` (`productCode`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `requestitems`
--
ALTER TABLE `requestitems`
  ADD CONSTRAINT `fk_requestItems_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `requestitems_ibfk_1` FOREIGN KEY (`RequestID`) REFERENCES `requests` (`RequestID`) ON UPDATE CASCADE;

--
-- Constraints for table `tbltransactions`
--
ALTER TABLE `tbltransactions`
  ADD CONSTRAINT `fk_approvedby` FOREIGN KEY (`ApprovedBy`) REFERENCES `tbladmin_users` (`admin_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_processedby` FOREIGN KEY (`ProcessedBy`) REFERENCES `tbladmin_users` (`admin_id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
