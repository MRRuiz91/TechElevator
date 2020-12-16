<template>
  <b-navbar id="footer" class="text-white mt-auto" toggleable="sm" variant="dark" type="dark border">
      
      <b-nav-text v-if="$store.state.token != ''">Thank you for all of your hard work!</b-nav-text>
      <b-nav-text v-else>Due to COVID-19 we are unable to allow you to visit our pets in person. Please contact us for more information about adoption.</b-nav-text>
      
      <b-navbar-nav class="ml-auto">
        <b-nav-item href="#" disabled>Contact Us</b-nav-item>
        <b-nav-item to="register">Volunteer Sign-up</b-nav-item>
      </b-navbar-nav>
  </b-navbar>
</template>

<script>
export default {

}
</script>

<style>
#footer {
  background-color: black !important;
}
</style>