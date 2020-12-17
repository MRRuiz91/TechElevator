<template>
  <b-navbar id="navBar" class="text-white" toggleable="lg" variant="dark" type="dark border">

      <b-navbar-brand to='/' class="ml-1"> <img src="..\assets\icon.png" class="img" height="45 px"/> Matt and Zach's Marvelous Zoo</b-navbar-brand>

      <b-navbar-nav class="ml-auto">
        <b-nav-item  to="/"><img src="..\assets\pawPrintOrangeL.png" class="img" height="45 px"/>Home</b-nav-item>

        <b-nav-item  to="logout" v-if="$store.state.token != ''"><img src="..\assets\pawPrintOrangeL.png" class="img" height="45 px"/>Logout</b-nav-item>

        <b-nav-item  to="login"  v-else><img src="..\assets\pawPrintOrangeL.png" class="img" height="45 px"/>Login</b-nav-item>

        <b-nav-item  to="volunteer-portal" v-if="$store.state.token != ''"><img src="..\assets\pawPrintOrangeL.png" class="img" height="45 px"/>Volunteer Portal</b-nav-item>

        <b-nav-item  to="register" v-else><img src="..\assets\pawPrintOrangeL.png" class="img" height="45 px"/>Sign up to Volunteer</b-nav-item>
      </b-navbar-nav>
  </b-navbar>
</template>

<script>
export default {
}
</script>

<style scoped>
#navBar {
  background-image: url('~@/assets/Navbar-flair-3.png') !important;
  background-color: black !important;
  background-size: contain;
  background-repeat: no-repeat;
}
</style>
