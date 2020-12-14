import axios from 'axios';

export default {
    getPendingApplications() {
        return axios.get('/applications')
    },
    ApproveOrDenyApplication(application) {
        return axios.put('/applications', application)
    },
    getVolunteerList() {
        return axios.get('')  
    },
}