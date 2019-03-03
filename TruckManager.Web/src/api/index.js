import axios from "axios";

const BASE_ADDRESS = "http://localhost:8080/api/"

export const addTanking = (tanking, id) => {
    return axios.put(BASE_ADDRESS+ "trucks/" + id,tanking,{
        headers:{'Content-Type': 'application/json'}
    } )
}

export const getTrucks = () => {
    return axios.get(BASE_ADDRESS + "trucks",{
        headers: {"Access-Control-Allow-Origin": "*"},
    })
}