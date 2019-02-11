import React from 'react';
import styles from './styles.module.scss';


const Greeting = (props) => {
    return(
        <div className={styles.greetingContainer} style={{backgroundImage: `url(${props.background})`, backgroundSize:"cover"}}>
            <div className={styles.greeting}>
                <p>Welcome {props.name}</p>
                <h1>{props.location}</h1>
            </div>
        </div>
    )
}
export default Greeting;