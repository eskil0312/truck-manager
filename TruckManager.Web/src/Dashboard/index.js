import React, { Component } from 'react';
import styles from  './styles.module.scss';
import Card from './components/Card';
import Cards from './components/Cards';
import Background from "../assets/images/asphalt-truck.jpg";
import Greeting from "../components/greeting";

export default class Dashboard extends Component {
    
    render() {
        
        return(
            <div className={styles.container}>
                <Greeting name="Eskil" location="My Dashboard" background={Background} />        
                <div className={styles.cards}>
                    {Cards.map(card => (
                        <div className={styles.card} key={card.key}> 
                            <Card content={card}/>
                        </div>
                    ))}
                </div>

            </div>
        )
    }
}