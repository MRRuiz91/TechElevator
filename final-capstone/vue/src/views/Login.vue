<template>
  <div id="login" class="text-center row">
    <div class="col-sm-4">
    </div>
  <b-card class="bg-dark text-white border col-sm-4">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal text-white">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div class="login ">
      <div class='row mb-3'>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      </div>

      <div class="row mb-3">
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      </div>
      </div>
      <div>
      <b-button class="bg-dark" type="submit">Sign in</b-button>
      <br>
      <router-link :to="{ name: 'register' }">Submit a Volunteer Application Here</router-link>
      </div>
    </form>
    </b-card>
    <div class="col-sm-4">
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";
export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
      .login(this.user)
      .then(response => {
        if (response.status == 200) {
          this.$store.commit("SET_AUTH_TOKEN", response.data.token);
          this.$store.commit("SET_USER", response.data.user);
          this.$router.push('volunteer-portal');
        }
      })
      .catch(error => {
        const response = error.response;
        if (response.status === 401) {
          this.invalidCredentials = true;
        }
      });
    }
  }
};
</script>
