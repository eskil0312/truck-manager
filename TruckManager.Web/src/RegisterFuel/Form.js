import React from 'react';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import styles from './styles.module.scss';
import CloudUploadIcon from '@material-ui/icons/CloudUpload';
import Button from '@material-ui/core/Button';

const currencies = [
    {
      value: 'USD',
      label: '$',
    },
    {
      value: 'EUR',
      label: '€',
    },
    {
      value: 'NOK',
      label: 'NOK',
    }
  ];
const fuelTypes = [
    {
        value:"gasoline",
        label:"Gasoline"
    },
    {
        value:"disel",
        label:"Disel"
    }
]
  

const Form = (props) => {

    const [values, setValues] = React.useState({
        regNumber:'',
        totalDistance: '',
        tankingCost: '',
        tankingQuantity: '',
        fuelType: 'disel',
        currency: 'NOK',

      });
      
    const handleChange = name => event => {
        setValues({ ...values, [name]: event.target.value });
      };

    return(
        <form className={styles.form}>
            <TextField
                id="reg-numbre"
                label="Reg Number"
                value={values.regNumber}
                onChange={handleChange('regNumber')}
                margin="normal"
            />
            <TextField
                id="total-distance"
                label="Total Distance"
                value={values.totalDistance}
                onChange={handleChange('totalDistance')}
                margin="normal"
            />
            <TextField
                id="tanking-cost"
                label="Tanking Cost"
                value={values.tankingCost}
                onChange={handleChange('tankingCost')}
                margin="normal"
            />
            <TextField
                id="tanking-quantity"
                label="Tanking Quantity"
                value={values.tankingQuantity}
                onChange={handleChange('tankingQuantity')}
                margin="normal"
            />
            <TextField
                id="standard-select-currency"
                select
                label="Select"
                value={values.currency}
                onChange={handleChange('currency')}
                SelectProps={{
                    MenuProps: {
                        style:{width:200},
                    },
                }}
                helperText="Please select your currency"
                margin="normal"
                >
                {currencies.map(option => (
                <MenuItem key={option.value} value={option.value}>
                    {option.label}
                </MenuItem>
                ))}
            </TextField>

            <TextField
                id="standard-select-fuel"
                select
                label="Select"
                value={values.fuelType}
                onChange={handleChange('fuelType')}
                SelectProps={{
                    MenuProps: {
                        style:{width:200},
                    },
                }}
                helperText="Please select your fuel"
                margin="normal"
                >
                {fuelTypes.map(option => (
                <MenuItem key={option.value} value={option.value}>
                    {option.label}
                </MenuItem>
                ))}
            </TextField>

            <Button variant="contained" color="default" className={styles.button} onClick={() => props.upload(values)}>
                Upload
                <CloudUploadIcon />
            </Button>
        </form>

    )
}
export default Form