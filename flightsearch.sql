alter procedure FlightSearch(
	@origin nvarchar(3),
	@destination nvarchar(3),
	@date datetime
)
as
set nocount on;

WITH connecting_flights AS (

  SELECT id, origin, destination,origin+'-'+Destination as [Path], Price, Departs, Arrives, 0 AS stops
  FROM flights where origin=@origin 

  UNION ALL

  SELECT cf.id, cf.origin, f.destination,(cf.[Path]+'-'+f.Destination) as [Path],(cf.price + f.price) as Price, cf.Departs, f.Arrives, cf.stops + 1 AS stops
  FROM flights f
  INNER JOIN connecting_flights cf ON cf.destination = f.origin
  WHERE cf.stops <= 2 and cf.origin <> f.destination 
		and f.origin <> @destination
)
--SELECT Origin, Destination,[Path], Price, Departs, Arrives, Stops
SELECT ID, Origin, Destination, Price, Departs, Arrives
FROM connecting_flights AS flights
where Destination = @destination
		and stops<3
order by price, Departs

return 0
 
