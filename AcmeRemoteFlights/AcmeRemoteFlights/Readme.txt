url
	
	List all flights:
	http://localhost:58088/api/flights
	 Rsponse:
	[{"FlightNumber":1,"StartTime":"2018-06-25T00:00:00+10:00","EndTime":"2018-06-25T05:00:00+10:00","PassengerCapacity":150,"DepartureCityDescription":"BRISBANE","ArrivalCityDescription":"PERTH","DepartureCityValue":1,"ArrivalCityValue":2},
	{"FlightNumber":2,"StartTime":"2018-06-25T01:00:00+10:00","EndTime":"2018-06-26T03:00:00+10:00","PassengerCapacity":150,"DepartureCityDescription":"BRISBANE","ArrivalCityDescription":"MELBOURNE","DepartureCityValue":1,"ArrivalCityValue":3},
	{"FlightNumber":4,"StartTime":"2018-06-25T00:00:00+10:00","EndTime":"2018-06-25T05:00:00+10:00","PassengerCapacity":150,"DepartureCityDescription":"PERTH","ArrivalCityDescription":"BRISBANE","DepartureCityValue":2,"ArrivalCityValue":1},
	{"FlightNumber":3,"StartTime":"2018-06-25T00:00:00+10:00","EndTime":"2018-06-25T07:00:00+10:00","PassengerCapacity":160,"DepartureCityDescription":"BRISBANE","ArrivalCityDescription":"SYDNEY","DepartureCityValue":1,"ArrivalCityValue":4}]
	
	Search for bookings
	http://localhost:58088/api/flights/FlightBookings/test1/2018-06-25/Melbourne/brisbane/2
	 Rsponse:
	[{"FlightNumber":2,"StartTime":"2018-06-25T01:00:00+10:00","EndTime":"2018-06-26T03:00:00+10:00","PassengerCapacity":150,"DepartureCityDescription":"1","ArrivalCityDescription":"3","DepartureCityValue":1,"ArrivalCityValue":3}]
	
	Check availability
	Rsponse:
	http://localhost:58088/api/flights/FlightAvailability/2018-06-25/2018-06-27/3
	[{"FlightNumber":1,"StartTime":"2018-06-25T00:00:00+10:00","EndTime":"2018-06-25T05:00:00+10:00","PassengerCapacity":150,"DepartureCityDescription":"1","ArrivalCityDescription":"2","DepartureCityValue":0,"ArrivalCityValue":0},{"FlightNumber":4,"StartTime":"2018-06-25T00:00:00+10:00","EndTime":"2018-06-25T05:00:00+10:00","PassengerCapacity":150,"DepartureCityDescription":"2","ArrivalCityDescription":"1","DepartureCityValue":0,"ArrivalCityValue":0},
	{"FlightNumber":2,"StartTime":"2018-06-25T01:00:00+10:00","EndTime":"2018-06-26T03:00:00+10:00","PassengerCapacity":150,"DepartureCityDescription":"1","ArrivalCityDescription":"3","DepartureCityValue":0,"ArrivalCityValue":0},{"FlightNumber":3,"StartTime":"2018-06-25T00:00:00+10:00","EndTime":"2018-06-25T07:00:00+10:00","PassengerCapacity":160,"DepartureCi
	
	Make booking
	http://localhost:58088/api/flights/MakeBooking/1/Test2/50
	
	Assumptions:
		FlightNumber is unique
		All the searc params are mandatory
		