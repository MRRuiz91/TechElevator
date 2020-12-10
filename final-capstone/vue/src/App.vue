<template>
  <div id="app" class="bg">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
export default {
 
    components: {
      Navbar
   
    }
  
}
</script>
<style>
 .bg {
     /* The image used */
    background-image: url("https://www.myfreetextures.com/wp-content/uploads/2014/10/seamless-panther-fur-texture-900x900.jpg") !important;
    background-color: black;
    /* Full height */
    height: auto;
    /* Center and scale the image nicely */
    background-repeat: repeat;
    background-position: center;
  }
  
</style>
