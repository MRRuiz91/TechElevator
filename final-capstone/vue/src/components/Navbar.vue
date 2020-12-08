<template>
      <b-navbar toggleable="med" type="dark" variant="danger"> 
      <b-link to="home">Home</b-link>&nbsp;|&nbsp;
      <b-link to="logout" v-if="$store.state.token != ''">Logout</b-link>
      <b-link to="login" v-else>Login</b-link>
    </b-navbar>
</template>

<script>
export default {

}
</script>

<style>
b-link a {
    font-weight: 500;
    color: white;
    text-decoration: none;
}
b-link a:hover {
    text-decoration: none;
}

</style>