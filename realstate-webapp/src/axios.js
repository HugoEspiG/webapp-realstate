import axios from 'axios'

axios.defaults.baseURL = "http://localhost:5279/api/";


if(JSON.parse(sessionStorage.getItem('rs-device'))!= null){
    var token = JSON.parse(sessionStorage.getItem('rs-device')).data
}else {
    var token = ""
}
axios.defaults.headers.common['Authorization'] = 'Bearer '+token;