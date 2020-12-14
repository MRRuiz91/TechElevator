<template>
  <b-navbar class="text-white" toggleable="med" variant="dark" type="dark border">
      <div><img class="img" src ="..\assets\MarvelousZoo.png" height="200px"/></div>

      <div>
        <b-link class = "text-white text-decoration-none" to="/"> 
        <img src="..\assets\pawPrint.png" class="img" height="45 px"/>Home</b-link>
          |
        <b-link class = "text-white text-decoration-none" to="logout" v-if="$store.state.token != ''">
        <img src="..\assets\pawPrint.png" class="img" height="45 px"/>Logout</b-link>
          
        <b-link class = "text-white text-decoration-none" to="login" v-else>
        <img src="..\assets\pawPrint.png" class="img" height="45 px"/>Login</b-link> 
          |
        <b-link class = "text-white text-decoration-none" to="volunteer-portal" v-if="$store.state.token != ''">
        <img src="..\assets\pawPrint.png" class="img" height="45 px"/>Volunteer Portal</b-link>
          
        <b-link class = "text-white text-decoration-none" to="register" v-else>
        <img src="..\assets\pawPrint.png" class="img" height="45 px"/>Sign up to Volunteer</b-link>
      </div>
  </b-navbar>
</template>

<script>
export default {
}
</script>

<style>
</style>