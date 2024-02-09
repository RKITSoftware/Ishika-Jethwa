use hotelmanagement;
-- Create Rooms Table
CREATE TABLE rom01 (
  m01f01 INT NOT NULL AUTO_INCREMENT COMMENT 'room_id' ,
  m01f02 INT NOT NULL COMMENT 'room_number',
  m01f03 VARCHAR(50) NOT NULL COMMENT 'room_type',
  m01f04 INT NOT NULL COMMENT 'capacity',
  PRIMARY KEY (m01f01)
)
COMMENT = 'RoomTable';

-- Create Guests Table
CREATE TABLE gus01 (
  s01f01 INT NOT NULL AUTO_INCREMENT COMMENT 'guest_id',
  s01f02 VARCHAR(50) NOT NULL COMMENT 'first_name',
  s01f03 VARCHAR(50) NOT NULL COMMENT 'last_name',
  s01f04 VARCHAR(100) COMMENT 'email',
  s01f05 VARCHAR(15) COMMENT 'phone_number',
  PRIMARY KEY (s01f01)
)
COMMENT = 'GuestsTable';

-- Create Reservations Table
CREATE TABLE rev01 (
  v01f01 INT NOT NULL AUTO_INCREMENT COMMENT 'reservation_id',
  v01f02 INT NOT NULL COMMENT 'guest_id',
  v01f03 INT NOT NULL COMMENT 'room_id',
  v01f04 DATE NOT NULL COMMENT 'checkin_date',
  v01f05 DATE NOT NULL COMMENT 'checkout_date',
  PRIMARY KEY (v01f01),
  FOREIGN KEY (v01f02) REFERENCES gus01(s01f01),
  FOREIGN KEY (v01f03) REFERENCES rom01(m01f01)
)
COMMENT = 'ReservationTable';

-- Insert Sample Data into Rooms Table
INSERT INTO rom01 (m01f02, m01f03, m01f04) VALUES
(101, 'Standard', 2),
(102, 'Deluxe', 3),
(201, 'Suite', 4);

-- Insert Sample Data into Guests Table
INSERT INTO gus01 (s01f02, s01f03, s01f04, s01f05) VALUES
('Ishika', 'Jethwa', 'isshika@example.com', '123-456-7890'),
('Deven', 'Jethwa', 'deven@example.com', '987-654-3210');

-- Insert Sample Data into Reservations Table
INSERT INTO rev01 (v01f02, v01f03, v01f04, v01f05) VALUES
(1, 1, '2024-01-01', '2024-01-05'),
(1, 1, '2024-01-15', '2024-01-17'),
(2, 3, '2024-02-10', '2024-02-12');

-- Retrieve all rooms
SELECT 
	m01f01,
    m01f02,
    m01f03,
    m01f04
FROM 
	rom01;

-- Retrieve all guests
SELECT 
	s01f01,
    s01f02,
    s01f03,
    s01f04,
    s01f05
FROM gus01;


-- Update check-out date for reservation with ID 1
UPDATE rev01
SET v01f05 = '2024-01-10'
WHERE v01f01 = 1;

-- Delete or cancle reservation with ID 2

DELETE FROM rev01
WHERE v01f01 = 2;


-- Retrieve all reservations with guest information
SELECT 
	rev01.*, 
    gus01.s01f02 AS guest_first_name, 
    gus01.s01f03 AS guest_last_name
FROM 
	rev01
JOIN 
	gus01 
ON 
	rev01.v01f02 = gus01.s01f01
LIMIT 
	1,2;


-- Retrieve the count of reservations for each day in the first month with guest details
create view vws_reservationDetails AS
SELECT
  rev01.v01f04 AS reservation_date,
  gus01.s01f02 AS guest_first_name,
  gus01.s01f03 AS guest_last_name,
  DATEDIFF(rev01.v01f05, rev01.v01f04) AS stay_duration
FROM
  rev01
JOIN
  gus01 ON rev01.v01f02 = gus01.s01f01
WHERE
  MONTH(rev01.v01f04) = 1 -- Assuming January is the first month
GROUP BY
  rev01.v01f04, gus01.s01f01;

select * from vws_reservationDetails;

drop view vws_reservationDetails;


