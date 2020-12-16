<template>
  <b-navbar id="navBar" class="text-white" bg-black toggleable="lg" variant="dark" type="dark border">
      <b-navbar-brand to='/'> <img src="..\assets\icon.png" class="img" height="45 px"/> Matt and Zach's Marvelous Zoo</b-navbar-brand>
     
      <b-navbar-nav class="ml-auto">
        <b-nav-item  to="/"><img src="..\assets\pawPrintOrange.png" class="img" height="45 px"/>Home</b-nav-item>

        <b-nav-item  to="logout" v-if="$store.state.token != ''"><img src="..\assets\pawPrintOrange.png" class="img" height="45 px"/>Logout</b-nav-item>

        <b-nav-item  to="login"  v-else><img src="..\assets\pawPrintOrange.png" class="img" height="45 px"/>Login</b-nav-item>

        <b-nav-item  to="volunteer-portal" v-if="$store.state.token != ''"><img src="..\assets\pawPrintOrange.png" class="img" height="45 px"/>Volunteer Portal</b-nav-item>

        <b-nav-item  to="register" v-else><img src="..\assets\pawPrintOrange.png" class="img" height="45 px"/>Sign up to Volunteer</b-nav-item>
      </b-navbar-nav>
  </b-navbar>
</template>

<script>
export default {
}
</script>

<style scoped>
#navBar {
  background-color: black !important;
}
</style>
