<template>
  <b-navbar class="text-white" toggleable="lg" variant="dark" type="dark border">
      <b-navbar-brand to='/'> <img src="..\assets\pawPrint.png" class="img" height="45 px"/> Matt and Zach's Marvelous Zoo</b-navbar-brand>
     
      <b-navbar-nav class="ml-auto">
        <b-nav-item  to="/"><img src="..\assets\pawPrint.png" class="img" height="45 px"/>Home</b-nav-item>

        <b-nav-item  to="logout" v-if="$store.state.token != ''"><img src="..\assets\pawPrint.png" class="img" height="45 px"/>Logout</b-nav-item>

        <b-nav-item  to="login"  v-else><img src="..\assets\pawPrint.png" class="img" height="45 px"/>Login</b-nav-item>

        <b-nav-item  to="volunteer-portal" v-if="$store.state.token != ''"><img src="..\assets\pawPrint.png" class="img" height="45 px"/>Volunteer Portal</b-nav-item>

        <b-nav-item  to="register" v-else><img src="..\assets\pawPrint.png" class="img" height="45 px"/>Sign up to Volunteer</b-nav-item>
      </b-navbar-nav>
  </b-navbar>
</template>

<script>
export default {
}
</script>

<style>
</style>