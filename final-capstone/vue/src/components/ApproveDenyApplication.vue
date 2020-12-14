<template>
   <b-table
        striped hover selectable :dark='true' b-table-select-single 
        :items="$store.state.pendingApplications" :fields="fields" 
        @row-selected="onRowSelected" responsive="sm" selected-variant="success"
    >
    <template #cell(Approve_or_Deny)="">
        <b-button size="sm" class="mr-1">
            Approve
        </b-button>
        <b-button size="sm" class="mr-1">
            Deny
        </b-button>
    </template>
    </b-table>
</template>

<script>
export default {
    data () {
        return {
            fields : [ 'Name', 'Response', 'Email', 'Phone Number', 'Decision'],

        }
    },
    methods: {
        
    },
}
</script>

<style>

</style>