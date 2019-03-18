import React, { Component } from 'react';
import Greeting from '../components/greeting';
import Background from "../assets/images/asphalt-truck.jpg";
import Form from './Form';
import { addTanking,getTrucks } from "../api";
import styles from "./styles.module.scss";
import TankingList from "./TankingList";

export default class RegisterFuel extends Component {

    state = {
        data:null
    }
    componentDidMount(){
        getTrucks()
        .then((response) => {
            const formData = response.data.find(d => d.id === "5c588cc970a45ab81c86e1f7").tankings;
            this.setState({ 
                data: formData
            });
        })
        .catch((error) => {
            console.log(error);
        })

    }

    upload = (values) => {
        const date = new Date()
        const valuesWithDate = {
            ...values,
            date: date.getDate().toString() + "." + date.getMonth().toString() + "." + date.getFullYear().toString() 
        }
        
        const id = "5c588cc970a45ab81c86e1f7"
        addTanking(valuesWithDate, id)
        .then((response) => {
            this.setState({
                data:response.data.tankings
            });
        })
        .catch((error) => {
            console.log(error);
        })
       
    }

    render(){
        const {data} = this.state;

        return(
            <React.Fragment>
                <Greeting name="Eskil" location="Register Fuel" background={Background} />
                    <div className={styles.regFuelContainer}>
                    <Form upload= {(values) => this.upload(values)}/>
                    {data ? <TankingList data={data}/> : null}
                </div>
            </React.Fragment>
            
        )
    }
}