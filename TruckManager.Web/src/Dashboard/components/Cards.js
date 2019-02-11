import Profile from "../../assets/images/profile.jpeg";
import RegFuel from "../../assets/images/gasoline.jpg";
import MngFuel from "../../assets/images/fuel-management.jpeg";

export default [
    {
        key:"profile",
        name:"Profile",
        description:"Shortcut to your profile page. The profile page gives basic information about the user, company and licence",
        img: Profile,
    },
    {
        key:"register-fuel",
        name:"Register Fuel Comsuption",
        description:"Shortcut to page for register fuel consuption. Here you can regeister the fuel consiption and the milage cover",
        img: RegFuel,
    },
    {
        key:"overview-fuel",
        name:"Fuel Usage Overview",
        description:"Shortcut to page for overview of fuel consuption for all registerd trucks and gives you the oppertunity to work with the data",
        img: MngFuel,
    }

]