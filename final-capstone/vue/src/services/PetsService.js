import axios from 'axios';

export default {

    getAllPets() {
        return axios.get('/pets');
    }

}