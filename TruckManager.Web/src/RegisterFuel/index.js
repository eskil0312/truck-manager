import React, { Component } from 'react';
import Greeting from '../components/greeting';
import Background from "../assets/images/asphalt-truck.jpg";
import Form from './Form';
import axios from 'axios';

export default class RegisterFuel extends Component {

    upload = (values) => {
        console.log(values)
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