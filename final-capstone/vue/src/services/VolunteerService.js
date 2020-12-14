import axios from 'axios';

export default {
    getPendingApplications() {
        return axios.get('')
    },
    ApproveOrDenyApplication(application) {
        return axios.put('', application)
    },
    getVolunteerList() {
        return axios.get('')  
    },
}