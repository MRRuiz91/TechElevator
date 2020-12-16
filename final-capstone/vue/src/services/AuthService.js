import axios from 'axios';

export default {
  login(user) {return axios.post('/login', user)},
  
  apply(application) {return axios.post('/apply', application)},

  changePassword(loginUser) {
    return axios.put('/users', loginUser)
  }
}
