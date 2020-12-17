<template>
  <div>
  <div class="text-center">
    <h1 class="h3 mb-3 font-weight-normal">Submit Volunteer Application</h1>
  </div>
    <div>
    <b-form class="form-register" @submit.prevent="register">
      
      

      <div class="alert alert-danger" role="alert" v-if="registrationErrors">{{ registrationErrorMsg }}</div>

      <b-form-group class = "contact-info" label="Username:" label-for="username">
        <b-form-input id="username" v-model="application.username" required placeholder="Enter username here"></b-form-input>
      </b-form-group>

      <b-form-group class = "contact-info" label="Email address:" label-for="email">
        <b-form-input id="email" v-model="application.email" type="email" required placeholder="e.g. your.email@email.com"></b-form-input>
      </b-form-group>

        <b-form-group class = "contact-info" label="Phone Number:" label-for="phone-number">
          <b-form-input id="phone-number" v-model="application.phone" required placeholder="e.g. (555)555-5555"></b-form-input>
        </b-form-group>

        <b-form-group class = "contact-info" label="First Name:" label-for="first-name">
          <b-form-input id="first-name" v-model="application.firstName" required placeholder="e.g. John"></b-form-input>
        </b-form-group>

        <b-form-group class = "contact-info" label="Last Name:" label-for="last-name">
          <b-form-input id="last-name" v-model="application.lastName" required placeholder="e.g. Smith"></b-form-input>
        </b-form-group>

        <b-form-group label="Why do you want to work with M and Z's as an adoption volunteer?" label-for="response">
          <b-textarea id="response" v-model="application.promptResponse" placeholder="Enter your answer here" rows="3" max-rows="8"></b-textarea>
        </b-form-group>
        <b-button type="submit" variant="outline-success">Submit</b-button>
    </b-form>
    </div>
  </div>
</template>

<script>
import authService from '@/services/AuthService.js';
export default {
  name: 'registerForm',
  data() {
        return {
        application : {
            username : '',
            phone : '',
            email : '',
            promptResponse : '',
            firstName : '',
            lastName : '',
            response : ''
        },
        registrationErrors: false,
        registrationErrorMsg: 'There were problems registering this user.',
        };
  },
  methods: {
    register() {
      this.clearErrors();
      authService
      .apply(this.application)
      .then((response) => {
        if (response.status == 201) {
          this.$router.push({path: '/', query: { registration: 'success' },
          });
        }
      })
      .catch((error) => {
        const response = error.response;
        this.registrationErrors = true;
        if (response.status === 400) {
          this.registrationErrorMsg = 'Bad Request: Validation Errors';
        }
      });
    },
    clearErrors() {
        this.registrationErrors = false;
        this.registrationErrorMsg = 'There were problems registering this user.';
    }
  }
}
</script>

<style>
</style>