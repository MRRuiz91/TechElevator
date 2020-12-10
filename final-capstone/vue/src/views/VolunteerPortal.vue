<template>
 <div class="volunteerPortal">
     <h1>volunteer see dis</h1>
  <div class="adminView" v-if="$store.state.user.role === 'admin'">
     <h1>admin see dis</h1>
 </div>   
 <div>
 <b-button><b-link to="add-pet"> 
          <img src="..\assets\pawPrint.png" class="img" height="50 px"/>
          Add Pet</b-link></b-button>
 <b-button><b-link to="update-pet"> 
          <img src="..\assets\pawPrint.png" class="img" height="50 px"/>
          Update Pet</b-link></b-button>
 </div>
 <div class="volunteerDirectory">
     <h1>volunteerDirectory</h1>
 </div>
  </div>
</template>
<script>
export default {
}
</script>
<style>
</style>