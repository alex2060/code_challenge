using System;
using Xunit;


namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            park.garage parking = new park.garage();
            bool add_floor = parking.add_floor();

            Assert.True(add_floor == true, "failed to add floor");

            Assert.True(parking.add_row_to_floor(0) == true, "failed to add row");

            Assert.True(parking.add_spot_row_of_floor(0, 0, "M") == true, "failed to add spot");

            park.spot check = parking.look_at_spot(0, 0, 0);

            Assert.True(check.occupied_by == "NONE", "Wrong value in spot");
            Assert.True(check.type_of_space == "M", "Wrong value in spot");

            Assert.True(parking.add_car(0, 0, 0, "C") == false, "should not have been added");

            Assert.True(parking.add_car(0, 0, 0, "M") == true, "should  have been added");

            Assert.True(parking.add_spot_row_of_floor(0, 0, "C") == true, "failed to add");


            Assert.True(parking.add_car(0, 0, 1, "B") == false, "should not have been added");

            Assert.True(parking.add_car(0, 0, 1, "C") == true, "should  have been added");

            Assert.True(parking.add_car(0, 0, 1, "M") == false, "should  not have been added");


            Assert.True(parking.add_car(0, 0, 1, "C") == false, "should be taken");


            Assert.True(parking.remove_spot(0, 0, 1) == true, "removed cycle");

            Assert.True(parking.add_car(0, 0, 1, "C") == true, "should be open");


            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "L"));

            Assert.True(parking.add_spot_row_of_floor(0, 0, "L") == true, "should be availble");


            Assert.True(parking.add_car(0, 0, 2, "B") == false, "should not be availble");


            Console.WriteLine("spots");
            parking.add_spot_row_of_floor(0, 0, "L");
            parking.add_spot_row_of_floor(0, 0, "L");
            parking.add_spot_row_of_floor(0, 0, "L");
            parking.add_spot_row_of_floor(0, 0, "L");
            parking.add_spot_row_of_floor(0, 0, "L");

            Assert.True(parking.add_car(0, 0, 2, "B") == true, "should be space");

            Assert.True(parking.add_car(0, 0, 3, "C") == false, "should not be space");


            park.spot check2 = parking.look_at_spot(0, 0, 3);


            Assert.True(check2.occupied_by == "B2", "Wrong value in spot");
            Assert.True(check2.type_of_space == "L", "Wrong value in spot");




            Assert.True(parking.remove_spot(0, 0, 2) == true, "removed bus");



            Assert.True(parking.remove_spot(0, 0, 2) == false, "should be gone");




            Assert.True(parking.add_car(0, 0, 3, "C") == true, "no car");



            Assert.True(parking.add_floor() == true, "should be able to add floor");
            Assert.True(parking.add_row_to_floor(1) == true, "should be a floor there");

            Assert.True(parking.add_row_to_floor(1) == true, "should be a floor there");

            Assert.True(parking.add_row_to_floor(7) == false, "should not a floor there");

            Assert.True(parking.add_spot_row_of_floor(1, 1, "M") == true, "should be a row on that floor");

            Assert.True(parking.add_spot_row_of_floor(8, 5, "M") == false, "should not be a row on that floor");






        }
    }
}
