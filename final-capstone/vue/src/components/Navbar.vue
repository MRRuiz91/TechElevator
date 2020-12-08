<template>
      <b-navbar toggleable="med" type="dark" variant="warning"> 
      <b-link class = "text-dark text-decoration-none" to="home">Home</b-link>
      <b-link class = "text-dark text-decoration-none" to="logout" v-if="$store.state.token != ''">Logout</b-link>
      <b-link class = "text-dark text-decoration-none" to="login" v-else>Login</b-link>
    </b-navbar>
</template>

<script>
export default {

}
</script>

<style>

</style>