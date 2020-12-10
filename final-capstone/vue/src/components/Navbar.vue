<template>
      <b-navbar toggleable="med"  type="dark" variant="warning"> 
      <div>
        
        <b-link class = "text-dark text-decoration-none" to="home"> 
          <img src="..\assets\pawPrint.png" class="img" height="20 px"/>
          Home
        </b-link>
      </div>
      <div>
        <img class="img" src ="..\assets\MarvelousZoo.png" height="100px"/>
      </div>
      <div>
      
        <b-link class = "text-dark text-decoration-none" to="logout" v-if="$store.state.token != ''">
          <img src="..\assets\pawPrint.png" class="img" height="20 px"/>
          Logout
        </b-link>

        <b-link class = "text-dark text-decoration-none" to="login" v-else>
          <img src="..\assets\pawPrint.png" class="img" height="20 px"/>
          Login
        </b-link> |

        <b-link class = "text-dark text-decoration-none" to="volunteer-portal" v-if="$store.state.token != ''">
          <img src="..\assets\pawPrint.png" class="img" height="20 px"/>
          Volunteer Portal
        </b-link>

        <b-link class = "text-dark text-decoration-none" to="register" v-else>
          <img src="..\assets\pawPrint.png" class="img" height="20 px"/>
          Register
        </b-link>
      </div>
    </b-navbar>
</template>

<script>
export default {

}
</script>

<style>

</style>