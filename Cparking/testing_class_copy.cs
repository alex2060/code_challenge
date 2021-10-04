using System;
using System.Collections.Generic;
namespace park




{


    class garage
    {
        List<floor> floors = new List<floor>();

        public bool add_floor()
        {
            Console.WriteLine(this.floors.Count);
            floor add = new floor();
            this.floors.Add(new floor());
            Console.WriteLine(this.floors.Count);


            return true;
        }

        public bool add_row_to_floor(int floor_number)
        {
            if (this.floors.Count > floor_number)//check for bound
            {
                floors[floor_number].add_row();
                return true;
            }

            return false;
        }

        public bool add_spot_row_of_floor(int floor_number, int row_number, string spot_type)
        {   //checks for bounds
            if (this.floors.Count > floor_number)
            {

                if (this.floors[floor_number].rows.Count > row_number)
                {
                    //adding spot
                    this.floors[floor_number].rows[row_number].add_spot(spot_type);

                }
                return true;
            }

            return false;
        }

        public bool add_car(int floor_number, int row_number, int parking_number, string car)
        {

            //checks for bounds
            if (this.floors.Count > floor_number)
            {
                if (this.floors[floor_number].rows.Count > row_number)
                {
                    if (this.floors[floor_number].rows[row_number].spots.Count > parking_number)
                    {

                        if (car == "B")// bus check
                        {
                            if (this.floors[floor_number].rows[row_number].spots.Count > parking_number + 4)// see if there are enough spaces 
                            {
                                // logic
                                bool check1 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by == "NONE";
                                bool check2 = this.floors[floor_number].rows[row_number].spots[parking_number + 1].occupied_by == "NONE";
                                bool check3 = this.floors[floor_number].rows[row_number].spots[parking_number + 2].occupied_by == "NONE";
                                bool check4 = this.floors[floor_number].rows[row_number].spots[parking_number + 3].occupied_by == "NONE";
                                bool check5 = this.floors[floor_number].rows[row_number].spots[parking_number + 4].occupied_by == "NONE";

                                bool check_space1 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].type_of_space == "L";
                                bool check_space2 = this.floors[floor_number].rows[row_number].spots[parking_number + 1].type_of_space == "L";
                                bool check_space3 = this.floors[floor_number].rows[row_number].spots[parking_number + 2].type_of_space == "L";
                                bool check_space4 = this.floors[floor_number].rows[row_number].spots[parking_number + 3].type_of_space == "L";
                                bool check_space5 = this.floors[floor_number].rows[row_number].spots[parking_number + 4].type_of_space == "L";

                                if (check1 && check2 && check3 && check4 && check5 && check_space1 && check_space2 && check_space3 && check_space4 && check_space5)
                                {
                                    // adding bus
                                    this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by = "B1";
                                    this.floors[floor_number].rows[row_number].spots[parking_number + 1].occupied_by = "B2";
                                    this.floors[floor_number].rows[row_number].spots[parking_number + 2].occupied_by = "B3";
                                    this.floors[floor_number].rows[row_number].spots[parking_number + 3].occupied_by = "B4";
                                    this.floors[floor_number].rows[row_number].spots[parking_number + 4].occupied_by = "B5";
                                    return true;
                                }
                                return false;

                            }


                        }
                        if (car == "C")//car check
                        {
                            bool check1 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by == "NONE";
                            bool check_space1 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].type_of_space == "L";
                            bool check_space2 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].type_of_space == "C";
                            bool check_space = check_space1 || check_space2;
                            if (check1 && check_space)
                            {
                                this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by = "C";
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }

                        if (car == "M")//cycle check
                        {

                            bool check1 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by == "NONE";
                            bool check_space1 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].type_of_space == "L";
                            bool check_space2 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].type_of_space == "C";
                            bool check_space3 = this.floors[floor_number].rows[row_number].spots[parking_number + 0].type_of_space == "M";
                            bool check_space = check_space1 || check_space2 || check_space3;
                            if (check1 && check_space)
                            {
                                //adding cycle
                                this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by = "M";
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool remove_spot(int floor_number, int row_number, int parking_number)
        {

            //checks for bounds
            if (this.floors.Count > floor_number)
            {
                if (this.floors[floor_number].rows.Count > row_number)
                {

                    if (this.floors[floor_number].rows[row_number].spots.Count > parking_number)
                    {

                        if (this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by == "M")//cycle check
                        {
                            this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by = "NONE";
                            return true;
                        }

                        if (this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by == "C")//car check
                        {
                            this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by = "NONE";
                            return true;
                        }

                        if (this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by == "B1")//car check
                        {
                            this.floors[floor_number].rows[row_number].spots[parking_number + 0].occupied_by = "NONE";
                            this.floors[floor_number].rows[row_number].spots[parking_number + 1].occupied_by = "NONE";
                            this.floors[floor_number].rows[row_number].spots[parking_number + 2].occupied_by = "NONE";
                            this.floors[floor_number].rows[row_number].spots[parking_number + 3].occupied_by = "NONE";
                            this.floors[floor_number].rows[row_number].spots[parking_number + 4].occupied_by = "NONE";
                            return true;
                        }


                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public spot look_at_spot(int floor_number, int row_number, int parking_number)
        {


            //checks for bounds
            if (this.floors.Count > floor_number)
            {

                if (this.floors[floor_number].rows.Count > row_number)
                {
                    if (this.floors[floor_number].rows[row_number].spots.Count > parking_number)
                    {
                        return this.floors[floor_number].rows[row_number].spots[parking_number + 0];
                        //spot invaild_spot = new spot();
                        //invaild_spot.change_type("Invlaid");


                    }
                }
            }



            spot invaild_spot = new spot();
            invaild_spot.change_type("Invlaid");

            return invaild_spot;



        }
    }


    class floor
    {

        public List<row> rows = new List<row>();
        public void add_row()
        {
            this.rows.Add(new row());
        }
    }

    class row
    {
        public List<spot> spots = new List<spot>();
        public void add_spot(String spot_type)
        {
            spot add = new spot();
            add.change_type(spot_type);
            this.spots.Add(add);
        }
    }

    class spot
    {
        public string occupied_by = "NONE";
        public string type_of_space = "NULL";
        public void change_type(string spot_type)
        {
            this.type_of_space = spot_type;
        }
    }




    /*

        class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //unit test
            garage parking = new garage();
            Console.WriteLine("add floor");
            Console.WriteLine(parking.add_floor());
            Console.WriteLine("add row");
            Console.WriteLine(parking.add_row_to_floor(0));
            Console.WriteLine("add spot");
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "M"));
            Console.WriteLine("space checks");
            spot check = parking.look_at_spot(0, 0, 0);

            Console.WriteLine(check.occupied_by);

            Console.WriteLine(check.type_of_space);

            Console.WriteLine("car in cycle spot");
            Console.WriteLine(parking.add_car(0, 0, 0, "C"));
            Console.WriteLine("cycle check");
            Console.WriteLine(parking.add_car(0, 0, 0, "M"));
            Console.WriteLine("add spot car");
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "C"));
            Console.WriteLine("buss check");
            Console.WriteLine(parking.add_car(0, 0, 1, "B"));
            Console.WriteLine("cycle check");
            Console.WriteLine(parking.add_car(0, 0, 1, "M"));
            Console.WriteLine("car check");
            Console.WriteLine(parking.add_car(0, 0, 1, "C"));

            Console.WriteLine("remove cycle");
            Console.WriteLine(parking.remove_spot(0, 0, 1));
            Console.WriteLine("car check");
            Console.WriteLine(parking.add_car(0, 0, 1, "C"));
            Console.WriteLine("Large check");
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "L"));
            Console.WriteLine("Bus check");
            Console.WriteLine(parking.add_car(0, 0, 2, "B"));
            Console.WriteLine("spots");
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "L"));
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "L"));
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "L"));
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "L"));
            Console.WriteLine(parking.add_spot_row_of_floor(0, 0, "L"));
            Console.WriteLine("bus check 2");
            Console.WriteLine(parking.add_car(0, 0, 2, "B"));
            Console.WriteLine("car check");
            Console.WriteLine(parking.add_car(0, 0, 3, "C"));

            Console.WriteLine("check spot 2");
            spot check2 = parking.look_at_spot(0, 0, 3);

            Console.WriteLine(check2.occupied_by);

            Console.WriteLine(check2.type_of_space);

            Console.WriteLine("remove bus");
            Console.WriteLine(parking.remove_spot(0, 0, 2));
            Console.WriteLine("car check");
            Console.WriteLine(parking.add_car(0, 0, 3, "C"));
            Console.WriteLine("add floor");
            Console.WriteLine(parking.add_floor());
            Console.WriteLine("add row");
            Console.WriteLine(parking.add_row_to_floor(1));
            Console.WriteLine("add row");
            Console.WriteLine(parking.add_row_to_floor(1));
            Console.WriteLine("check add");
            Console.WriteLine(parking.add_spot_row_of_floor(1, 1, "M"));








        }

    }


    */




}




