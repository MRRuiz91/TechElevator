<template>
  <div id="app">
    <navbar />
    <router-view class="m-5"/>
    <the-footer/>
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
/*
a {
  text-decoration: none !important;
}
*/
#app {
  height: 100% !important;
  display: flex;
  flex-direction: column;
}
/*.container {
  display: grid;
  grid-template-areas: 
  "nav nav nav" 
  "body body body"
  "footer footer footer";
  width: 100vw;
}
.footer {
  grid-area:footer;
  height: 10vh;
  
}
.body {
  grid-area: body;
  height: 80vh;
}
.nav {
  grid-area: nav;
  height: 10vh;
  width: 90vw;
}*/
</style>
