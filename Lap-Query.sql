SELECT * FROM Room;
SELECT * FROM RoomAmenity;

SELECT TOP(1) RoomID, COUNT(*) AS number_of_amenities from RoomAmenity GROUP BY RoomID ORDER BY number_of_amenities DESC;