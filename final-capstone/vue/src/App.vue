<template>
  <div id="app" class="bg">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
export default {
  components: {Navbar}
}
</script>

<style>
.bg {  
  background-image: url("https://www.myfreetextures.com/wp-content/uploads/2014/10/seamless-panther-fur-texture-900x900.jpg") !important;
  background-color: black;
  height: auto;
  background-size: cover;
  background-repeat: repeat;
  background-position: center;
}
</style>
