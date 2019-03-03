import React, { Component } from 'react';
import Greeting from '../components/greeting';
import Background from "../assets/images/asphalt-truck.jpg";
import Form from './Form';
import { addTanking,getTrucks } from "../api";

export default class RegisterFuel extends Component {

    upload = (values) => {
        console.log(values)
        const newValue = {
            date:"2.23.2013",
            distance:133,
            cost:133,
            currency:"NOK",
            quantityLiter:11
        }
        getTrucks()
        .then((response) => {
            console.log(response);
        })
        .catch((error) => {
            console.log(error);
        })

        const id = "5c588cc970a45ab81c86e1f7"
        addTanking(newValue, id)
        .then((response) => {
            console.log(response);
        })
        .catch((error) => {
            console.log(error);
        })
       
    }

    render(){
        return(
            <div>
                <Greeting name="Eskil" location="Register Fuel" background={Background} />
                <Form upload= {(values) => this.upload(values)}/>
            </div>
        )
    }
}