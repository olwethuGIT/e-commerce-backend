-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 15, 2022 at 01:32 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `store`
--
CREATE DATABASE IF NOT EXISTS `store` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `store`;

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `Id` varchar(95) NOT NULL,
  `title` longtext DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `price` float NOT NULL,
  `OrderId` char(36) CHARACTER SET ascii NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`Id`, `title`, `quantity`, `price`, `OrderId`) VALUES
('2022-03-03 14:17:46.963592', 'Men\'s Black Medium Wash Skinny Jeans', 1, 249.99, '08d9fd0f-e4a3-4d88-85d2-10503e75ae4e'),
('2022-03-03 14:17:47.988398', 'Men\'s Black Muscle Fit T-Shirt', 1, 69.99, '08d9fd0f-e4a3-4d88-85d2-10503e75ae4e'),
('2022-03-03 15:04:07.427957', 'Men\'s Black Medium Wash Skinny Jeans', 2, 249.99, '08d9fd16-5050-46af-8feb-add76b896e8a'),
('2022-03-03 15:07:24.657294', 'Men\'s Black Medium Wash Skinny Jeans', 1, 249.99, '08d9fd16-c6e5-42b4-8b8e-69dd21ce12b8'),
('2022-03-03 15:07:25.476747', 'Men\'s Black Muscle Fit T-Shirt', 1, 69.99, '08d9fd16-c6e5-42b4-8b8e-69dd21ce12b8'),
('2022-03-03 19:07:49.159044', 'Men\'s Black Medium Wash Skinny Jeans', 1, 249.99, '08d9fd38-5ebd-421e-899d-e0f8ffe52a07'),
('2022-03-03 19:07:50.660273', 'Men\'s Black Muscle Fit T-Shirt', 1, 69.99, '08d9fd38-5ebd-421e-899d-e0f8ffe52a07');

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `Id` char(36) CHARACTER SET ascii NOT NULL,
  `Amount` float NOT NULL,
  `CreatedAt` longtext DEFAULT NULL,
  `Username` varchar(95) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`Id`, `Amount`, `CreatedAt`, `Username`) VALUES
('08d9fd0f-e4a3-4d88-85d2-10503e75ae4e', 319.98, '2022-03-03T14:18:08.368856', 'olwethu@theapplab.co.za'),
('08d9fd16-5050-46af-8feb-add76b896e8a', 499.98, '2022-03-03T15:04:11.231297', 'olwethu@theapplab.co'),
('08d9fd16-c6e5-42b4-8b8e-69dd21ce12b8', 319.98, '2022-03-03T15:07:30.656766', 'olwethu@theapplab.co'),
('08d9fd38-5ebd-421e-899d-e0f8ffe52a07', 319.98, '2022-03-03T19:07:58.241723', 'olwethu@theapplab.co.za');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `Id` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `ImageUrl` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`Id`, `Title`, `Description`, `Price`, `ImageUrl`) VALUES
(1, 'Men\'s Black Muscle Fit T-Shirt', 'This Tee will go well with everything in your \'drobe. Featuring a crew neckline, slim-cut sleeves and tight fit to the body.', 69.99, 'https://image.tfgmedia.co.za/image/1/process/486x486?source=https://cdn.tfgmedia.co.za/17/ProductImages/57569866.jpg'),
(2, 'Men\'s Black Medium Wash Skinny Jeans', 'Look fresh when you pair these jeans with a graphic t-shirt & sneakers for a look we like. Featuring a black denim stretch fabric, elasticated waistband, and washed detailing.', 249.99, 'https://image.tfgmedia.co.za/image/1/process/486x486?source=https://cdn.tfgmedia.co.za/17/ProductImages/59244053.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `Username` varchar(95) NOT NULL,
  `PasswordHash` longblob NOT NULL,
  `PasswordSalt` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`Username`, `PasswordHash`, `PasswordSalt`) VALUES
('olwethu@theapplab.co', 0xb8f656296f05ddc478eae24f6505399326f67c83888989f135242f1a513fb8132bda2dc9144634e378f6fdbf4d08c23bff4b272f9fa7a4148d634394b5b49a48, 0xe813a3ff4da590385c5fed692609776257eadb3d89e3c79ced002b24b058f48e7fb9bef2ee95267c545c039de77e93fbe2356dd48879617a19c3a373457c9b1e7c6e298aa9915c256617cfc4bd078ee9bd5ccae7e8ce9be50a13ff6b04e98a23b3c9cc328f1683d2d30127eb114c28b4e455cb84ca4b86b3ef561457065a58f6),
('olwethu@theapplab.co.za', 0xef2cd4b6dffe0366117fb85471d50f424a7ce7817f9152404afa45c1475a7636c3a811ecc63f74f9082257538f6cabddbbf075d797eb05fd31e5b698ada394df, 0xeb374796fd064a2ded4b8043cd8a72d9ac56dc959ab17f455ef92d4f5e4af354c31785814282c14895e8498bb6355b43cc4be076a96033e1848af92f32e24559da50d19a7d7b7092d3f07e295102c542ff65e7e6b393e700247980dd9d91f95efd321270158add10d817580ad18ba6fa8151dfbabc1099103ea0bb8f65adc7a5);

-- --------------------------------------------------------

--
-- Table structure for table `userfavorite`
--

CREATE TABLE `userfavorite` (
  `Id` int(11) NOT NULL,
  `Username` varchar(95) DEFAULT NULL,
  `ProductId` int(11) NOT NULL DEFAULT 0,
  `IsFavorite` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `userfavorite`
--

INSERT INTO `userfavorite` (`Id`, `Username`, `ProductId`, `IsFavorite`) VALUES
(1, 'olwethu@theapplab.co', 2, 0),
(2, 'olwethu@theapplab.co', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220303121036_InitialCreate', '6.0.1'),
('20220304100406_AddedFavoriteClass', '6.0.1'),
('20220308062935_UpdatingOrders', '6.0.1');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Cart_OrderId` (`OrderId`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Order_Username` (`Username`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Username`);

--
-- Indexes for table `userfavorite`
--
ALTER TABLE `userfavorite`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_UserFavorite_Username` (`Username`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `userfavorite`
--
ALTER TABLE `userfavorite`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `FK_Cart_Order_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `order` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `FK_Order_User_Username` FOREIGN KEY (`Username`) REFERENCES `user` (`Username`);

--
-- Constraints for table `userfavorite`
--
ALTER TABLE `userfavorite`
  ADD CONSTRAINT `FK_UserFavorite_User_Username` FOREIGN KEY (`Username`) REFERENCES `user` (`Username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
