<template>
  <div id="app" >
    <navbar />
    <router-view />
    <the-footer />
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import TheFooter from './components/TheFooter.vue'
export default {
  components: {Navbar, TheFooter}
}
</script>

<style>
body {  
  background-image: url("https://www.myfreetextures.com/wp-content/uploads/2014/10/seamless-panther-fur-texture-900x900.jpg") !important;
  background-color: black;
  height: 100vh;
  width: 100vw;
  background-size: auto;
  background-repeat: repeat;
  background-position: center;
  background-attachment: fixed;

}
a {
  text-decoration: none !important;
}
</style>
