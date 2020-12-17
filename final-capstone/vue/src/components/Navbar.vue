<template>
  <b-navbar id="navBar" class="text-white" toggleable="lg" variant="dark" type="dark border">

      <b-navbar-brand to='/' id="brand"> <img src="..\assets\iconO.png" class="img" height="45 px"/> Matt and Zach's Marvelous Zoo</b-navbar-brand>

      <b-navbar-nav>
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
  background-position-y: bottom;
  background-position-x: left;
}
#brand {
  margin-left: 10%;
}
.navbar-nav {
  margin-left: auto;
}

@media only screen and (max-width: 768px) {
    #navBar {
    background-image: url('~@/assets/Navbar-flair-3.png') !important;
    background-color: black !important;
    background-size: contain;
    background-repeat: no-repeat;
    background-position-y: bottom;
    background-position-x: left;

  }
  #brand {
    margin-left: 5%;
  }
  .navbar-nav {
    flex-direction: row;
    margin: 0 5% 15%;
    justify-content: space-between !important;
  }
  
  .img {
    height: 20px !important;
  }
}
</style>
