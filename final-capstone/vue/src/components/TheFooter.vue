<template>
  <b-navbar id="footer" class="text-white mt-auto" toggleable="sm" variant="dark" type="dark border">
      <div>
      <b-nav-text v-if="$store.state.token != ''">Thank you for all of your hard work!</b-nav-text>
      <b-nav-text v-else>Due to COVID-19 we are unable to allow you to visit our pets in person. Please contact us for more information about adoption.</b-nav-text>
      </div>
      <b-navbar-nav class="ml-auto" id="nav">
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
  background-image: url('~@/assets/navbar-flair-3-flipped.png') !important;
  background-color: black !important;
  background-size: contain;
  background-position-x: right;
  background-position-y: bottom;

  background-repeat: no-repeat;
  }
#nav {
  margin-right:5%;
}
@media only screen and (max-width: 768px) {
  #footer {
  background-image: url('~@/assets/navbar-flair-3-flipped.png') !important;
  background-color: black !important;
  background-size: contain;
  background-position-x: right;
  background-position-y: bottom;

  background-repeat: no-repeat;
  }
#nav {
  margin-left: 0 !important;
}
}

</style>